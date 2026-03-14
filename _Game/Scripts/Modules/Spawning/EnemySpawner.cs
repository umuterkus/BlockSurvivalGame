using System;
using System.Collections.Generic;
using System.Threading;
using BlockSurvive.Entities.Enemy;
using BlockSurvive.Entities.Player;
using BlockSurvive.Interfaces;
using BlockSurvive.Settings;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace BlockSurvive.Modules.Spawning
{
    public class EnemySpawner : IInitializable, IDisposable
    {
        private readonly EnemyController.Pool _enemyPool;
        private readonly ITarget _target;
        private readonly List<EnemySettingsSO> _enemySettingsList;
        private CancellationTokenSource _cts;

        public EnemySpawner(EnemyController.Pool enemyPool, ITarget target, List<EnemySettingsSO> enemySettingsList)
        {
            _enemyPool = enemyPool;
            _target = target;
            _enemySettingsList = enemySettingsList;
        }

        public void Initialize()
        {
            _cts = new CancellationTokenSource();
            SpawnRoutine(_cts.Token).Forget();
        }

        private async UniTaskVoid SpawnRoutine(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);

                EnemySettingsSO randomSO = _enemySettingsList[UnityEngine.Random.Range(0, _enemySettingsList.Count)];

                EnemyController newEnemy = _enemyPool.Spawn();

                Vector2 randomDir = UnityEngine.Random.insideUnitCircle.normalized;
                Vector2 spawnPos = (Vector2)_target.Transform.position + randomDir * randomSO.spawnRadius;

                newEnemy.transform.position = spawnPos;
                newEnemy.InitializeEnemy(randomSO);
            }
        }

        public void Dispose()
        {
            _cts?.Cancel();
            _cts?.Dispose();
        }
    }
}