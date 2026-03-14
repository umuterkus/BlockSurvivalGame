using System.Collections.Generic;
using BlockSurvive.Entities.Enemy;
using UnityEngine;
namespace BlockSurvive.Modules
{
    public class EnemyRegistry
    {
        private readonly List<EnemyController> _activeEnemies = new();
        public void Register(EnemyController enemy) => _activeEnemies.Add(enemy);
        public void Unregister(EnemyController enemy) => _activeEnemies.Remove(enemy);
        public Transform GetNearest(Vector2 position)
        {
            Transform nearest = null;
            float closestDistance = float.MaxValue; //first enemy always closer than infinty so thats why
            foreach (var enemy in _activeEnemies)
            {
                float distance = Vector2.Distance(position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    nearest = enemy.transform;
                }
            }
            return nearest;
        }
    }
}