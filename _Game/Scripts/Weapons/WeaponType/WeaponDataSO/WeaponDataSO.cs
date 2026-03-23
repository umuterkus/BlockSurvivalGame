using UnityEngine;

namespace BlockSurvive.Weapons
{
    public abstract class WeaponDataSO : ScriptableObject
    {
        public WeaponType weaponType;
        public string weaponName;
        public int damage;
        public float cooldown;
    }
}