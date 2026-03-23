using UnityEngine;

namespace BlockSurvive.Settings
{
    [CreateAssetMenu(fileName = "Passive Upgrades", menuName = "BlockSurvive/Passive Upgrades")]
    public class PassiveUpgradeDataSO : ScriptableObject
    {
        [Header("Info")]
        public string upgradeName;
        public Sprite upgradeIcon;
        public string description;

        [Header("Applied for next level")]
        public float damageMultiplier;
        public float projectileSpeed;
        public float weaponCooldown;
        public float weaponScale;
        public int projectileCount;
        public float healthRegen;
    }
}
