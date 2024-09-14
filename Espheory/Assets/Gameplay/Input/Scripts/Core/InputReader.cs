#region

using UnityEngine.InputSystem;
using Zenject;

#endregion

namespace Gameplay.Input.Core
{
    public class InputReader : Controls.IPlayerActions
    {
        #region Private Variables

        private Controls inputMapping;

        [Inject]
        private IInputService inputService;

        #endregion

        #region Public Methods

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
                    inputService.InputRecorder.TrackingSelect.Started();
                    break;
                case InputActionPhase.Performed:
                    inputService.InputRecorder.TrackingSelect.Performed();
                    break;
                case InputActionPhase.Canceled:
                    inputService.InputRecorder.TrackingSelect.Canceled();
                    break;
            }
        }

        #endregion
    }
}
