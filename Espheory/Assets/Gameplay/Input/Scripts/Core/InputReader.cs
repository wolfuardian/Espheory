#region

using Zenject;
using UnityEngine.InputSystem;

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

        #endregion
    }
}
