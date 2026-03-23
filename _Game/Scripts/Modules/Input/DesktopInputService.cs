using BlockSurvive.Modules.InputSystem.Interfaces;
using UnityEngine;
using Zenject;

namespace BlockSurvive.Modules.InputSystem.Service
{
    public class DesktopInputService : IInputService, ITickable
    {
        private Vector2 _direction;
        public Vector2 MovementDirection => _direction;

        public void Tick()
        {
            _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            
        }
    }
}
