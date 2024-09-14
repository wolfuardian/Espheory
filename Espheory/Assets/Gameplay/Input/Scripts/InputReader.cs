#region

using UnityEngine.InputSystem;
using Zenject;

#endregion

namespace Gameplay.Input.Scripts
{
    public interface IInputReader
    {
    }

    public class InputReader : Controls.IPlayerActions, IInputReader
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

        public void OnSelect(InputAction.CallbackContext  context) => inputHandler.OnSelect(context);
        public void OnPointer(InputAction.CallbackContext context) => inputHandler.OnPointer(context);

        #endregion
    }
}
