using UnityEngine.InputSystem;
using Zenject;

namespace Espheory.System.Player
{
    public interface IInputReader
    {
        #region Public Methods

        bool IsSelectKeyDown();

        #endregion
    }

    public class InputReader : GameInput.IPlayerActions, IInputReader
    {
        private GameInput gameInput;

        private bool isSelectKeyDown;

        [Inject]
        public void Construct()
        {
            gameInput = new GameInput();
            gameInput.Player.SetCallbacks(this);
            gameInput.Player.Enable();
        }

        public void OnSelect(InputAction.CallbackContext context)
        {
            if (context.started)
                isSelectKeyDown = true;
            if (context.canceled)
                isSelectKeyDown = false;
        }

        public void OnPointer(InputAction.CallbackContext context)
        {
        }


        public bool IsSelectKeyDown()
        {
            return isSelectKeyDown;
        }
    }
}