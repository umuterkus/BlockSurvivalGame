using BlockSurvive.Interfaces;
using BlockSurvive.Settings;
using UnityEngine;

namespace BlockSurvive.Entities.Enemy.States
{
    public class EnemyAttackState : IEnemyState
    {
        private readonly IDamageable _target;

        private float _attackTimer;
        
        private readonly EnemySettingsSO _enemySettingsSO;
        public EnemyAttackState(IDamageable target, EnemySettingsSO enemySettingsSO)
        {
            _target = target;
            _enemySettingsSO = enemySettingsSO;
        }

        public void Enter()
        {
            _attackTimer = _enemySettingsSO.attackCooldown;
        }

        public void Tick()
        {

            _attackTimer += Time.deltaTime;

            if (_attackTimer >= _enemySettingsSO.attackCooldown)
            {
                _target.TakeDamage(_enemySettingsSO.damage);
                _attackTimer = 0f;
            }
        }

        public void Exit()
        {
            _attackTimer = 0f;
        }
    }
}