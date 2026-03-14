using BlockSurvive.Entities.Player;
using BlockSurvive.Interfaces;
using BlockSurvive.Settings;
using UnityEngine;

namespace BlockSurvive.Entities.Enemy.States
{
    public class EnemyChaseState : IEnemyState
    {
        private readonly ITarget _target;
        private readonly Transform _enemyTransform;
        private readonly Rigidbody2D _rb;
        private readonly EnemySettingsSO _enemySettingsSO;
        public EnemyChaseState(Transform enemyTransform, ITarget target, Rigidbody2D rb, EnemySettingsSO enemySettingsSO)
        {
            _enemyTransform = enemyTransform;
            _target = target;
            _rb = rb;
            _enemySettingsSO = enemySettingsSO;

        }
        public void Enter()
        {
        }

        public void Tick()
        {
            Vector2 direction = (_target.Transform.position - _enemyTransform.position).normalized;

            Vector2 targetPosition = _rb.position + (Vector2)direction * (_enemySettingsSO.moveSpeed * Time.deltaTime);
            _rb.MovePosition(targetPosition);
        }

        public void Exit()
        {
        }
    }
}