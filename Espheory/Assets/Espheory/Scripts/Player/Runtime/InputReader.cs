using UnityEngine.InputSystem;
using Zenject;

namespace Espheory.Player
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
            // TODO: 這裡要用最簡單的方式實現壓住按鍵不放的時候，就不再重複觸發 Select 的邏輯。
            if (context.started)
            {
                isSelectKeyDown = true;
            }

            if (context.canceled)
            {
                isSelectKeyDown = false;
            }
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