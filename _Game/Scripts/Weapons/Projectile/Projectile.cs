using BlockSurvive.Entities.Enemy;
using BlockSurvive.Interfaces;
using UnityEngine;
using Zenject;


namespace BlockSurvive.Weapons
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private Vector2 _direction;
        private float _speed;
        private int _damage;
        
        private Pool _pool;
        public void SetPool(Pool pool) => _pool = pool;
        public class Pool : MonoMemoryPool<Projectile>
        {
            protected override void OnSpawned(Projectile projectile)
            {
                base.OnSpawned(projectile);
                projectile.SetPool(this);

            }
        }

        public void Initialize(Sprite sprite, Vector2 direction, float speed, int damage)
        {
            _direction = direction;
            _speed = speed;
            _damage = damage;
            _spriteRenderer.sprite = sprite;
        }
        private void Update()
        {
            transform.position += (Vector3)_direction * (_speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(_damage);
                _pool.Despawn(this);

            }
        }
    }

}