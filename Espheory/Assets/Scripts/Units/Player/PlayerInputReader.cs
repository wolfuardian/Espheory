using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Espheory
{
    public class PlayerInputReader : Controls.IPlayerActions
    {
        readonly IInputState _inputState;

        Controls _controls;

        public PlayerInputReader(IInputState inputState)
        {
            _inputState = inputState;
        }

        [Inject]
        public void Construct()
        {
            _controls = new Controls();
            _controls.Player.SetCallbacks(this);
            _controls.Player.Enable();
        }

        public void OnSelect(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    _inputState.IsSelecting = true;
                    break;
                case InputActionPhase.Canceled:
                    _inputState.IsSelecting = false;
                    break;
            }
        }

        public void OnPointer(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    _inputState.Pointer = context.ReadValue<Vector2>();
                    break;
            }
        }
    }
}
