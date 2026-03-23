using BlockSurvive.Entities.Player;
using BlockSurvive.Interfaces;
using BlockSurvive.Modules;
using UnityEngine;



namespace BlockSurvive.Weapons
{
    public class DaggersWeapon : IWeapon
    {


        private readonly Projectile.Pool _projectilePool;
        private readonly ITarget _target;

        private readonly float _speed;
        private readonly int _damage;
        private readonly float _cooldown;
        private readonly Sprite _sprite;
        private readonly int _projectileCount;
        private readonly PlayerStats _playerStats;
        public DaggersWeapon(ProjectileWeaponData data, PlayerStats playerStats, Projectile.Pool projectilePool, ITarget target)
        {
            _projectilePool = projectilePool;
            _target = target;
            
            _speed = data.projectileSpeed;
            _damage = data.damage;
            _cooldown = data.cooldown;
            _sprite = data.projectileSprite;
            _projectileCount = data.projectileCount;
            _playerStats = playerStats;
            Debug.Log("Daggers PlayerStats: " + playerStats.GetHashCode());


        }

        private float _timer = 0;
        public void Tick()
        {
            _timer += Time.deltaTime;

            var finalCooldown = _cooldown * _playerStats.WeaponCooldown;


            if (_timer > finalCooldown)
            {
                var finalDamage = (int)(_damage * _playerStats.DamageMultiplier);
                var finalSpeed = _speed * _playerStats.ProjectileSpeed;
                var finalProjectileAmount = _projectileCount + _playerStats.ProjectileCount;


                Projectile projectile = _projectilePool.Spawn();

                Vector3 spawnPos = _target.Transform.position + _target.Transform.right * 0.5f;
                projectile.transform.position = spawnPos;

                Vector2 direction = _target.Transform.right;

            

                projectile.Initialize(_sprite , direction, finalSpeed, finalDamage);
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
