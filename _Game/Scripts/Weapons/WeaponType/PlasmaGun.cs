using System;
using System.Threading;
using BlockSurvive.Entities.Enemy;
using BlockSurvive.Entities.Player;
using BlockSurvive.Interfaces;
using BlockSurvive.Modules;
using UnityEngine;



namespace BlockSurvive.Weapons
{
    public class PlasmaGun : IWeapon
    {
        

        private readonly EnemyRegistry _enemyRegistry;
        private readonly Projectile.Pool _projectilePool;
        private readonly ITarget _target;
        public PlasmaGun(EnemyRegistry enemyRegistry, Projectile.Pool projectilePool, ITarget target)
        {
            _enemyRegistry = enemyRegistry;
            _projectilePool = projectilePool;
            _target = target;
        }

        private float _timer = 0;
        public void Tick()
        {
            _timer += Time.deltaTime;

            if (_timer > 1)
            {
                Transform target = _enemyRegistry.GetNearest(_target.Transform.position);

                if (target == null) return;
                Vector2 direction = ((Vector2)target.position - (Vector2)_target.Transform.position).normalized;

                Projectile projectile = _projectilePool.Spawn();

                projectile.transform.position = _target.Transform.position;

                projectile.Initialize(direction, 5, 1);
                _timer = 0;
                
            }



        }

    }

}



