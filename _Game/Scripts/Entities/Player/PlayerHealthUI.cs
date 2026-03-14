using BlockSurvive.Entities.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BlockSurvive.UI
{
    public class PlayerHealthPresenter : MonoBehaviour
    {
        [SerializeField] private Image _healthFillImage; 

        private PlayerHealth _playerHealth; 
     

        [Inject]
        public void Construct(PlayerHealth playerHealth)
        {
            _playerHealth = playerHealth;
        }

        private void OnEnable()
        {
            if (_playerHealth != null)
            {
                _playerHealth.OnHealthChanged += UpdateHealthUI;
            }
        }

        private void OnDisable()
        {

            if (_playerHealth != null)
            {
                _playerHealth.OnHealthChanged -= UpdateHealthUI;
            }
        }

        private void UpdateHealthUI(int currentHealth, int maxHealth)
        {

            float healthPercentage = (float)currentHealth / maxHealth; // 

            _healthFillImage.fillAmount = healthPercentage;
        }
    }
}