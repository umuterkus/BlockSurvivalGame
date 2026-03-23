using System.Collections.Generic;
using BlockSurvive.Settings;
using UnityEngine;
using Zenject;

public class GameSettingsInstaller : MonoInstaller
{
    [SerializeField] private List<EnemySettingsSO> _enemyList;
    [SerializeField] private List<PassiveUpgradeDataSO> _passiveUpgradeList;

    public override void InstallBindings()
    {
        Container.BindInstance(_enemyList).AsSingle();
        Container.BindInstance(_passiveUpgradeList).AsSingle();
    }
}
