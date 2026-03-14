using System.Collections.Generic;
using BlockSurvive.Settings;
using UnityEngine;
using Zenject;

public class GameSettingsInstaller : MonoInstaller
{
    [SerializeField] private List<EnemySettingsSO> _enemyList;

    public override void InstallBindings()
    {
        Container.BindInstance(_enemyList).AsSingle();
    }
}
