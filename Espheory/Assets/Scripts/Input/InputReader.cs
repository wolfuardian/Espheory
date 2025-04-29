using Zenject;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Input.Core
{
    public class InputReader : Controls.IPlayerActions
    {
        private Controls inputMapping;

        [Inject] private IInputService inputService;

        [Inject]
        public void Construct()
        {
            inputMapping = new Controls();
            inputMapping.Player.SetCallbacks(this);
            inputMapping.Player.Enable();
        }

        public void OnSelect(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    inputService.InputTrack.TpSelect.Started();
                    break;
                case InputActionPhase.Performed:
                    inputService.InputTrack.TpSelect.Performed();
                    break;
                case InputActionPhase.Canceled:
                    inputService.InputTrack.TpSelect.Canceled();
                    break;
            }
        }

        public void OnPointer(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    inputService.SetPointerPosition(context.ReadValue<Vector2>());
                    break;
            }
        }
    }
}
