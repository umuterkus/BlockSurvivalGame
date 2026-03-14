using System;
using System.Collections.Generic;
using BlockSurvive.Collectibles;
using BlockSurvive.Entities.Enemy;
using BlockSurvive.Entities.Player;
using BlockSurvive.Handlers;
using BlockSurvive.Interfaces;
using BlockSurvive.Modules;
using BlockSurvive.Modules.InputSystem.Service;
using BlockSurvive.Modules.LevelSystem;
using BlockSurvive.Modules.Spawning;
using BlockSurvive.Signals;
using BlockSurvive.Weapons;
using UnityEngine;
using Zenject;

namespace BlockSurvive.Core.Installers
{
    
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private GameObject xpCrystalPrefab;
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            BindInputSystem();
            BindEnemySystem();
            BindPlayerPosition();
            BindWeaponSystem();
            BindXPSystem();
        }

        private void BindPlayerPosition()
        {
            Container.Bind<ITarget>().To<PlayerTarget>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PlayerHealth>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IDamageable>().FromComponentInHierarchy().AsSingle();
        }

        private void BindInputSystem()
        {
            Container.BindInterfacesTo<DesktopInputService>().AsSingle();
        }

        private void BindWeaponSystem()
        {
            Container.Bind<WeaponController>().FromComponentInHierarchy().AsSingle();

            Container.BindMemoryPool<Projectile, Projectile.Pool>()
                .WithInitialSize(10)
                .FromComponentInNewPrefab(projectilePrefab)
                .UnderTransformGroup("ProjectilePool");

            Container.BindInterfacesTo<PlasmaGun>().AsSingle();
        }

        private void BindXPSystem()
        {
            Container.DeclareSignal<EnemyDeathSignal>();
            Container.DeclareSignal<XPCollectedSignal>();
            Container.DeclareSignal<XPChangedSignal>();

            Container.BindMemoryPool<XPCrystal, XPCrystal.Pool>()
                .WithInitialSize(25)
                .FromComponentInNewPrefab(xpCrystalPrefab)
                .UnderTransformGroup("XpPool");

            Container.BindInterfacesTo<XPDropHandler>().AsSingle();
            Container.BindInterfacesTo<QuadraticLevelCalculator>().AsSingle();
            Container.BindInterfacesTo<PlayerProgressManager>().AsSingle();
        }
        private void BindEnemySystem() 
        {
            Container.BindMemoryPool<EnemyController, EnemyController.Pool>()
                .WithInitialSize(15) 
                .FromComponentInNewPrefab(enemyPrefab)
                .UnderTransformGroup("EnemyPool");

            Container.BindInterfacesTo<EnemySpawner>().AsSingle();

            Container.Bind<EnemyRegistry>().AsSingle();

        }







    }
}