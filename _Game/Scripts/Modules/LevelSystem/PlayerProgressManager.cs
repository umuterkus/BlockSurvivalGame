using System;
using BlockSurvive.Interfaces;
using BlockSurvive.Signals;
using UnityEngine;
using Zenject;


namespace BlockSurvive.Modules.LevelSystem
{

    public class PlayerProgressManager : IInitializable, IDisposable
    {
        private int _totalXP;
        private SignalBus _signalBus;
        private ILevelCalculator _levelCalculator;
        private int _currentLevel;
        private int _xpToNextLevel;
        public PlayerProgressManager(SignalBus signalBus, ILevelCalculator levelCalculator)
        {
            _signalBus = signalBus;
            _levelCalculator = levelCalculator;

        }
        public void Initialize()
        {
            _signalBus.Subscribe<XPCollectedSignal>(OnXPCollected);
            _currentLevel = 1;
            _xpToNextLevel = _levelCalculator.XPToNextLevel(1);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<XPCollectedSignal>(OnXPCollected);
        }

        public void OnXPCollected(XPCollectedSignal signal)
        {
            _totalXP += signal.XPValue;


            if (_totalXP >= _xpToNextLevel)
            {
                _totalXP -= _xpToNextLevel;
                _currentLevel++;
                _xpToNextLevel = _levelCalculator.XPToNextLevel(_currentLevel);
            }
            _signalBus.Fire(new XPChangedSignal { CurrentXP = _totalXP, XPToNextLevel = _xpToNextLevel, CurrentLevel = _currentLevel });
        }

    }
}