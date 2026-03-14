using BlockSurvive.Entities.Enemy.States;
using BlockSurvive.Entities.Player;
using BlockSurvive.Interfaces;
using BlockSurvive.Modules;
using BlockSurvive.Settings;
using BlockSurvive.Signals;
using UnityEngine;
using Zenject;


namespace BlockSurvive.Entities.Enemy {

    public class EnemyController : MonoBehaviour
    {
        private IEnemyState _currentState;
        private IEnemyState _chaseState;
        private IEnemyState _attackState;
        
        private ITarget _target;
        private IDamageable _damageable;
        private Health _health;

        private Rigidbody2D _rb;
        private EnemySettingsSO _enemySettingsSO;
        [SerializeField] private float _attackRange;

        private SpriteRenderer _spriteRenderer;

        private Pool _pool;
        public void SetPool(Pool pool) => _pool = pool;

        private SignalBus _signalBus;
        public class Pool : MonoMemoryPool<EnemyController>
        {
            [Inject] private readonly EnemyRegistry _registry;
            protected override void OnSpawned(EnemyController item)
            {
                base.OnSpawned(item);
                _registry.Register(item);
                item.SetPool(this);
                item.SubscribeDeath();
            }
            protected override void OnDespawned(EnemyController item)
            {
                base.OnDespawned(item);
                _registry.Unregister(item);
                item.UnsubscribeDeath();
            }
        }

        [Inject]
        public void Construct(ITarget target, IDamageable damageable, SignalBus signalBus)
        {
            _target = target;
            _damageable = damageable;
            _signalBus = signalBus;
        }

        public void SubscribeDeath()
        {
            _health.OnDeath += OnDeath;
        }

        public void UnsubscribeDeath()
        {
            _health.OnDeath -= OnDeath;
        }
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _health = GetComponent<Health>();
            _rb = GetComponent<Rigidbody2D>();
            _chaseState = new EnemyChaseState(this.transform, _target, _rb, _enemySettingsSO);
            _attackState = new EnemyAttackState(_damageable, _enemySettingsSO);
        }

        private void OnDeath()
        {
            _signalBus.Fire(new EnemyDeathSignal { Position = transform.position, XPValue = _enemySettingsSO.xpAmount });
            _pool.Despawn(this);
        }

        private void FixedUpdate()
        {
            
            _currentState?.Tick();
            float distance = Vector2.Distance(this.transform.position, _target.Transform.position);
            if (distance <= _attackRange && _currentState != _attackState)
            {
                ChangeState(_attackState);
            }
            else if (distance > _attackRange && _currentState != _chaseState)
            {
                ChangeState(_chaseState);
            }
        }

        public void InitializeEnemy(EnemySettingsSO enemySettingsSO) 
        {
            _enemySettingsSO = enemySettingsSO;
            _spriteRenderer.sprite = enemySettingsSO.enemySprite;

            _health.ResetHealth(enemySettingsSO.maxHealth);

            _chaseState = new EnemyChaseState(this.transform, _target, _rb, _enemySettingsSO);
            _attackState = new EnemyAttackState(_damageable, _enemySettingsSO);
            ChangeState(_chaseState);

        }

        public void ChangeState(IEnemyState newState)
        {
            _currentState?.Exit();

            _currentState = newState;

            _currentState?.Enter();
        }
    }

}










