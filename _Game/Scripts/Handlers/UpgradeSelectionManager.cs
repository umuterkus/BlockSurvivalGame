using System;
using System.Collections.Generic;
using BlockSurvive.Entities.Player;
using BlockSurvive.Interfaces;
using BlockSurvive.Modules.LevelSystem;
using BlockSurvive.Settings;
using BlockSurvive.Signals;
using UnityEngine;
using Zenject;

namespace BlockSurvive.Handlers
{
    public class UpgradeSelectionManager : IInitializable, IDisposable
    {
        private SignalBus _signalBus;
        private PlayerStats _playerStats;
        private List<PassiveUpgradeDataSO> _passiveUpgrades;

        public UpgradeSelectionManager(SignalBus signalBus, PlayerStats playerStats, List<PassiveUpgradeDataSO> passiveUpgrades)       
        {
            _signalBus = signalBus;
        }
        public void Initialize()
        {
            _signalBus.Subscribe<ShowUpgradeScreenSignal>(OnShowUpgradeScreen);


        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<ShowUpgradeScreenSignal>(OnShowUpgradeScreen);


        }

        private void OnShowUpgradeScreen(ShowUpgradeScreenSignal signal)
        {
            //show upgrade screen

            for (int i = 0; i < _passiveUpgrades.Count; i++)
            {
                var upgrade = _passiveUpgrades[i];
            }







        }
    }
}