using System;
using BlockSurvive.Entities.Player;
using BlockSurvive.Interfaces;
using BlockSurvive.Modules;
using UnityEngine;

namespace BlockSurvive.Weapons
{
    public class WeaponFactory
    {
        private readonly WeaponDatabase _weaponDatabase;
        private readonly ITarget _target;
        private readonly EnemyRegistry _enemyRegistry;
        private readonly Projectile.Pool _projectilePool;
        private readonly PlayerStats _playerStats;
        public WeaponFactory(WeaponDatabase weaponDatabase, PlayerStats playerStats, ITarget target, EnemyRegistry enemyRegistry, Projectile.Pool projectilePool)
        {
            _weaponDatabase = weaponDatabase;
            _target = target;
            _enemyRegistry = enemyRegistry;
            _projectilePool = projectilePool;
            _playerStats = playerStats;
        }

        public IWeapon CreateWeapon(WeaponType weaponType)
        {
            var weaponData = _weaponDatabase.weapons.Find(w => w.weaponType == weaponType);
            if (weaponData == null)
            {
                Debug.LogError($"Weapon data for {weaponType} not found!");
                return null;
            }

            return weaponType switch
            {
                //Cast for WeaponDataSO specialists
                WeaponType.Daggers => new DaggersWeapon((ProjectileWeaponData)weaponData, _playerStats, _projectilePool, _target),
                WeaponType.PlasmaGun => new PlasmaGunWeapon((ProjectileWeaponData)weaponData, _playerStats, _projectilePool, _enemyRegistry, _target),
                WeaponType.Garlic => new GarlicWeapon((AuraWeaponData)weaponData, _playerStats, _target),
                _ => throw new ArgumentOutOfRangeException(nameof(weaponType), $"Weapon type {weaponType} is not supported.")
            };


        }



    }
}