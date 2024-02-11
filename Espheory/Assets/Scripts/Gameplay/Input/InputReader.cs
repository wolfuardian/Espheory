using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Eos.Gameplay.Input
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
    public class InputReader : ScriptableObject, GameInput.IPlayerActions
    {
        #region Field Declarations

        public event UnityAction<Vector2> PointerEvent      = delegate { };
        public event UnityAction          SelectEvent       = delegate { };
        public event UnityAction          SelectCancelEvent = delegate { };

        private GameInput gameInput;

        #endregion

        private void OnEnable()
        {
            if (gameInput == null)
            {
                gameInput = new GameInput();
                gameInput.Player.Enable();
                gameInput.Player.SetCallbacks(this);
            }
        }


        public void OnSelect(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    break;
                case InputActionPhase.Performed:
                    // Debug.Log("InputReader: Select performed");
                    SelectEvent.Invoke();
                    break;
                case InputActionPhase.Canceled:
                    // Debug.Log("InputReader: Select canceled");
                    SelectCancelEvent.Invoke();
                    break;
            }
        }

        public void OnLookAround(InputAction.CallbackContext context)
        {
        }

        public void OnMoveForward(InputAction.CallbackContext context)
        {
        }

        public void OnMoveHorizontal(InputAction.CallbackContext context)
        {
        }

        public void OnMoveVertical(InputAction.CallbackContext context)
        {
        }

        public void OnPointerDelta(InputAction.CallbackContext context)
        {
        }

        public void OnPointer(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    // Debug.Log("InputReader: PointerPosition started");
                    break;
                case InputActionPhase.Performed:
                    // Debug.Log("InputReader: PointerPosition performed");
                    PointerEvent.Invoke(context.ReadValue<Vector2>());
                    break;
                case InputActionPhase.Canceled:
                    // Debug.Log("InputReader: PointerPosition canceled");
                    break;
            }
        }

        public void OnNextDollyLevel(InputAction.CallbackContext context)
        {
        }

        public void OnDodge(InputAction.CallbackContext context)
        {
        }

        public void OnTurnAround(InputAction.CallbackContext context)
        {
        }

        public void OnLockOnTarget(InputAction.CallbackContext context)
        {
        }

        public void OnUnlockTarget(InputAction.CallbackContext context)
        {
        }

        public void OnNextTarget(InputAction.CallbackContext context)
        {
        }

        public void OnPrevTarget(InputAction.CallbackContext context)
        {
        }
    }
}