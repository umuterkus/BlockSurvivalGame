using BlockSurvive.Entities.Player;
using BlockSurvive.Signals;
using UnityEngine;
using Zenject;

namespace BlockSurvive.Collectibles
{

    public class XPCrystal : MonoBehaviour
    {

        private int _xpValue;

        private Pool _pool;

        private SignalBus _signalBus;
        public void SetPool(Pool pool) => _pool = pool;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        public class Pool : MonoMemoryPool<XPCrystal>
        {
            protected override void OnSpawned(XPCrystal xpCrystal)
            {
                base.OnSpawned(xpCrystal);
                xpCrystal.SetPool(this);

            }
        }
        public void Initialize(int xpValue)
        {
            _xpValue = xpValue;

        }

        private void OnTriggerEnter2D(Collider2D other)
        {

            if (other.TryGetComponent<PlayerMovement>(out var player))
            {
                Debug.Log($"Picked up {_xpValue} XP!");

                _signalBus.Fire(new XPCollectedSignal { XPValue = _xpValue });
                _pool.Despawn(this);
            }


        }


    }
}
