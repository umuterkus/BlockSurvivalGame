using System.Collections.Generic;
using UnityEngine;

namespace BlockSurvive.Weapons
{
    [CreateAssetMenu(menuName = "Weapons/Projectile Weapon")]
    public class ProjectileWeaponData : WeaponDataSO
    {
        public float projectileSpeed;
        public int projectileCount;
        public Sprite projectileSprite;
    }
}