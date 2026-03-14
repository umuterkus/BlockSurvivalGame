using System;
using BlockSurvive.Interfaces;
using UnityEngine;

namespace BlockSurvive.Entities.Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxHealth = 100;
        private int _currentHealth;

        public event Action<int, int> OnHealthChanged;

        private void Start()
        {
            _currentHealth = _maxHealth;
        }
        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);

            if (_currentHealth <= 0)
            {
            }
        }
    }
}