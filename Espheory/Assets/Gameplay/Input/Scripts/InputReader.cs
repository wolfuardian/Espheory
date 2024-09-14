#region

using Zenject;
using UnityEngine.InputSystem;

#endregion

namespace Gameplay.Input.Scripts
{
    public class InputReader : Controls.IPlayerActions
    {
        #region Private Variables

        private Controls gameControls;

        [Inject]
        private IInputService inputService;

        #endregion

        #region Public Methods

        [Inject]
        public void Construct()
        {
            gameControls = new Controls();
            gameControls.Player.SetCallbacks(this);
            gameControls.Player.Enable();
        }

        public void OnSelect(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    inputService.Select.Initiate();
                    break;
                case InputActionPhase.Performed:
                    inputService.Select.Perform();
                    break;
                case InputActionPhase.Canceled:
                    inputService.Select.Reset();
                    break;
            }
        }

        #endregion
    }
}
