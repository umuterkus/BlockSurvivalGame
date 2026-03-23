using UnityEngine;


namespace BlockSurvive.Entities.Player
{



    public class PlayerStats
    {
        public float DamageMultiplier { get; private set; } = 1f;
        public float ProjectileSpeed { get; private set; } = 1f;
        public float WeaponScale { get; private set; } = 1f;
        public float WeaponCooldown { get; private set; } = 1f;
        public int ProjectileCount { get; private set; } = 0;
        public float HealthRegen { get; private set; } = 0f;
        public void AddDamageMultiplier(float amount)
        {
            DamageMultiplier += amount;
        }

        public void AddProjectileSpeed(float amount)
        {
            ProjectileSpeed += amount;
        }

        public void AddWeaponScale(float amount)
        {
            WeaponScale += amount;
        }

        public void AddWeaponCooldown(float amount)
        {
            WeaponCooldown -= amount;
        }

        public void AddHealthRegenation(float amount)
        {
            HealthRegen += amount;
        }

        public void AddProjectileCount(int amount)
        {
            ProjectileCount += amount;
        }



    }
}