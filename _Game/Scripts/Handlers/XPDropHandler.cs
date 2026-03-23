using System;
using BlockSurvive.Collectibles;
using BlockSurvive.Signals;
using UnityEngine;
using Zenject;

namespace BlockSurvive.Handlers

{
    public class XPDropHandler : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly XPCrystal.Pool _pool;

        public XPDropHandler(SignalBus signalBus, XPCrystal.Pool pool)
        {
            _signalBus = signalBus;
            _pool = pool;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<EnemyDeathSignal>(OnEnemyDeath);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<EnemyDeathSignal>(OnEnemyDeath);
        }

        private void OnEnemyDeath(EnemyDeathSignal signal)
        {
            XPCrystal crystal = _pool.Spawn();
            crystal.transform.position = signal.Position;
            crystal.Initialize(signal.XPValue);
        }

    }
}