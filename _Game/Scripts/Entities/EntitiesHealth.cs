using System;
using BlockSurvive.Interfaces;
using UnityEngine;

namespace BlockSurvive.Entities
{
    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxHealth = 100;
        private int _currentHealth;
        public event Action OnDeath;
        private bool _isDead;
        private void Start()
        {
            if (_currentHealth == 0) // if nobody called ResetHealth (scene object)
                ResetHealth(_maxHealth);
        }
        public void ResetHealth(int maxHealth)
        {
            _currentHealth = maxHealth;
            _isDead = false;
        }
        public void TakeDamage(int damage)
        {
            if (_isDead) return;
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                _isDead = true;
                OnDeath?.Invoke();
            }
        }
    }
}