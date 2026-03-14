using BlockSurvive.Signals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
namespace BlockSurvive.UI
{
    public class XPBarUI : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private TextMeshProUGUI _currentLevelText;
        [SerializeField] private Image _xpBarImage;


        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Start()
        {
            _signalBus.Subscribe<XPChangedSignal>(OnXPChanged);
            _xpBarImage.fillAmount = 0;
            _currentLevelText.text = "LV1";
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<XPChangedSignal>(OnXPChanged);
        }

        private void OnXPChanged(XPChangedSignal signal)
        {
            _xpBarImage.fillAmount = (float)signal.CurrentXP / signal.XPToNextLevel;
            _currentLevelText.text = $"LV{signal.CurrentLevel}";
        }

    }
}