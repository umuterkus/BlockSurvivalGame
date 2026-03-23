using BlockSurvive.Modules.InputSystem.Interfaces;
using UnityEngine;
using Zenject;

namespace BlockSurvive.Entities.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _moveSpeed = 5f;

        private IInputService _inputProvider;
        private Rigidbody2D _rigidbody;

        [Inject]
        public void Construct(IInputService inputProvider)
        {
            _inputProvider = inputProvider;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {

            Vector2 movementInput = _inputProvider.MovementDirection;

            Vector2 targetPosition = _rigidbody.position + movementInput * (_moveSpeed * Time.fixedDeltaTime);

            _rigidbody.MovePosition(targetPosition);
            if (movementInput.sqrMagnitude > 0.01f)
            {
                float angle = Mathf.Atan2(movementInput.y, movementInput.x) * Mathf.Rad2Deg;
                _rigidbody.SetRotation(angle); 
            }
        }
    }
}