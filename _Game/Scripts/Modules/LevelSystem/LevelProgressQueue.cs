using System;
using BlockSurvive.Interfaces;
using BlockSurvive.Signals;
using UnityEngine;
using Zenject;

namespace BlockSurvive.Modules.LevelSystem
{
    public class LevelProgressQueue : IInitializable, IDisposable
    {
        private SignalBus _signalBus;

        private int _levelsToProcess;

        private bool _isProcessing;
        public LevelProgressQueue(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        public void Initialize()
        {
            _isProcessing = false;
            _signalBus.Subscribe<LevelUpSignal>(OnLevelUp);
            _signalBus.Subscribe<UpgradeSelectedSignal>(OnUpgradeSelected);

        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<LevelUpSignal>(OnLevelUp);
            _signalBus.Unsubscribe<UpgradeSelectedSignal>(OnUpgradeSelected);

        }

        private void OnLevelUp(LevelUpSignal signal)
        {
            _levelsToProcess += signal.LevelsGained;

            Time.timeScale = 0f;
            // Pause the game while processing level-ups
            // Level up part is not ready.

            if (_isProcessing)
                return;

            _isProcessing = true;
            _signalBus.Fire(new ShowUpgradeScreenSignal());

        }
        private void OnUpgradeSelected()
        {
            _levelsToProcess--;
            if (_levelsToProcess > 0)
            {
                _signalBus.Fire(new ShowUpgradeScreenSignal());
            }
            else
            {
                _isProcessing = false;
            }
        }
    }

}