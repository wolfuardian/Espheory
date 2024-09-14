#region

using UnityEngine;
using Zenject;
using UnityEngine.InputSystem;

#endregion

namespace Gameplay.Input.Scripts
{
    public class InputReader : Controls.IPlayerActions
    {
        #region Private Variables

        private Controls controls;

        [Inject]
        private IInputService inputService;

        #endregion

        #region Public Methods

        [Inject]
        public void Construct()
        {
            controls = new Controls();
            controls.Player.SetCallbacks(this);
            controls.Player.Enable();
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
                    Debug.Log("dadsassa");
                    break;
                case InputActionPhase.Canceled:
                    inputService.Select.Reset();
                    break;
            }
        }

        #endregion
    }
}
