using UnityEngine;

namespace BlockSurvive.Settings
{
    [CreateAssetMenu(fileName = "Upgrade Data", menuName = "BlockSurvive/Upgrade Settings")]
    public class UpgradeDataSO : ScriptableObject
    {
        [Header("Upgrade Settings")]
        public string upgradeName;
        public Sprite upgradeIcon;
        public string description;
        [Header("Upgrade Effects")]
        public float damageMultiplier = 1f;
        public float speedMultiplier = 1f;
        public float healthMultiplier = 1f;
        public float xpMultiplier = 1f;
    }

}
