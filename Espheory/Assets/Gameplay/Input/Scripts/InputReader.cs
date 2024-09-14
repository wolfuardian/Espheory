#region

using Zenject;
using UnityEngine.InputSystem;

#endregion

namespace Gameplay.Input.Scripts
{
    public class InputReader : Controls.IPlayerActions
    {
        #region Private Variables

        private Controls inputMapping;

        [Inject]
        private IInputHandler inputHandler;

        #endregion

        #region Public Methods

        [Inject]
        public void Construct()
        {
            inputMapping = new Controls();
            inputMapping.Player.SetCallbacks(this);
            inputMapping.Player.Enable();
        }

        public void OnSelect(InputAction.CallbackContext context) => inputHandler.OnSelect(context);

        #endregion
    }
}
