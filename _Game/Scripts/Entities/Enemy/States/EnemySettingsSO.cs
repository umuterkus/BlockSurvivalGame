using UnityEngine;

namespace BlockSurvive.Settings
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "BlockSurvive/Enemy Settings")]
    public class EnemySettingsSO : ScriptableObject
    {
        [Header("Sprite")]
        public Sprite enemySprite;

        [Header("Movement")]
        public float moveSpeed = 5f;

        [Header("Health")]
        public int maxHealth = 100;

        [Header("Attack")]
        public int damage = 10;
        public float attackCooldown = 1f;

        [Header("Spawning")]
        public float spawnRadius = 10f;
        public float spawnInterval = 1f;

        [Header("XP")]
        public int xpAmount = 1;    

    }
}
