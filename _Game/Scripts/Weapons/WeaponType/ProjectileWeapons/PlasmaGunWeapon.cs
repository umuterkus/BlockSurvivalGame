using BlockSurvive.Entities.Enemy;
using BlockSurvive.Entities.Player;
using BlockSurvive.Interfaces;
using BlockSurvive.Modules;
using UnityEngine;



namespace BlockSurvive.Weapons
{
    public class PlasmaGunWeapon : IWeapon
    {

        private readonly EnemyRegistry _enemyRegistry;
        private readonly Projectile.Pool _projectilePool;
        private readonly ITarget _target;
        private readonly PlayerStats _playerStats;

        private readonly float _speed;
        private readonly int _damage;
        private readonly float _cooldown;
        private readonly Sprite _sprite;
        private readonly int _projectileCount;

        public PlasmaGunWeapon(ProjectileWeaponData data, PlayerStats playerStats, Projectile.Pool projectilePool, EnemyRegistry enemyRegistry, ITarget target)
        {
            _enemyRegistry = enemyRegistry;
            _projectilePool = projectilePool;
            _target = target;

            _speed = data.projectileSpeed;
            _damage = data.damage;
            _cooldown = data.cooldown;
            _sprite = data.projectileSprite;
            _projectileCount = data.projectileCount;
            _playerStats = playerStats;
        }

        private float _timer = 0;
        public void Tick()
        {
            _timer += Time.deltaTime;

            var finalCooldown = _cooldown * _playerStats.WeaponCooldown;

            if (_timer > finalCooldown)
            {
                Transform nearestEnemy = _enemyRegistry.GetNearest(_target.Transform.position);

                if (nearestEnemy == null) return;

                var finalDamage = (int)(_damage * _playerStats.DamageMultiplier);
                var finalSpeed = _speed * _playerStats.ProjectileSpeed;
                var finalProjectileAmount = _projectileCount + _playerStats.ProjectileCount;

                Vector2 direction = ((Vector2)nearestEnemy.position - (Vector2)_target.Transform.position).normalized;

                Projectile projectile = _projectilePool.Spawn();
                projectile.transform.position = _target.Transform.position;
                projectile.Initialize(_sprite, direction, finalSpeed, finalDamage);

                if (finalProjectileAmount > 1)
                {
                    for (int i = 1; i < finalProjectileAmount; i++)
                    {
                        Projectile extraProjectile = _projectilePool.Spawn();
                        Vector3 randomSpawnPos = _target.Transform.position + (_target.Transform.up * Random.Range(-1f, 1f)) + (_target.Transform.right * Random.Range(-0.5f, 0.5f));
                        extraProjectile.transform.position = randomSpawnPos;

                        extraProjectile.Initialize(_sprite, direction, finalSpeed, finalDamage);
                    }
                }

                _timer = 0;
            }
        }

    }

}