using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Eos.Gameplay.Input
{
    [CreateAssetMenu(menuName = "Game/Input/Input Reader")]
    public class InputReader : ScriptableObject, GameInput.IPlayerActions
    {
        #region Field Declarations

        public event UnityAction<Vector2> PointerEvent = delegate { };
        public event UnityAction<bool>    SelectEvent  = delegate { };
        public  Vector2                   Pointer => _gameInput.Player.Pointer.ReadValue<Vector2>();
        private GameInput                 _gameInput;

        #endregion

        private void OnEnable()
        {
            if (_gameInput != null) return;
            _gameInput = new GameInput();
            _gameInput.Player.Enable();
            _gameInput.Player.SetCallbacks(this);
        }

        public void OnSelect(InputAction.CallbackContext context)
        {
            if (context.performed)
                SelectEvent.Invoke(true);
            if (context.canceled)
                SelectEvent.Invoke(false);
        }

        public void OnPointer(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                PointerEvent.Invoke(context.ReadValue<Vector2>());
        }
    }
}