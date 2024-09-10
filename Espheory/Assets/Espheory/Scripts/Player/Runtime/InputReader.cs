#region

using UnityEngine.InputSystem;
using Zenject;

#endregion

namespace Espheory.Player
{
    public interface IInputReader
    {
        #region Public Methods

        bool IsSelectKeyStarted();
        bool IsSelectKeyPerformed();
        bool IsSelectKeyCanceled();

        #endregion
    }

    public class InputReader : InputKeyMapper.IPlayerActions, IInputReader
    {
        #region Private Variables

        private InputKeyMapper inputKeyMapping;

        [Inject] private IInputKey selectInputKey;

        private bool isSelectKeyStarted;
        private bool isSelectKeyPerformed;
        private bool isSelectKeyCanceled;

        #endregion

        #region Public Methods

        [Inject]
        public void Construct()
        {
            inputKeyMapping = new InputKeyMapper();
            inputKeyMapping.Player.SetCallbacks(this);
            inputKeyMapping.Player.Enable();
        }

        public void OnSelect(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                // TODO: This could be the entry point for verifying logic.
            }
            
            if (context.performed)
            {
                selectInputKey.SetKeyPerformed();
            }

            if (context.canceled)
            {
                selectInputKey.SetKeyCanceled();
            }
        }

        public void OnPointer(InputAction.CallbackContext context)
        {
            // TODO: This will serve as the logic code for the cursor on the screen.
        }

        public bool IsSelectKeyStarted()
        {
            return selectInputKey.IsKeyStarted();
        }

        public bool IsSelectKeyPerformed()
        {
            return selectInputKey.IsKeyPerformed();
        }

        public bool IsSelectKeyCanceled()
        {
            return selectInputKey.IsKeyCanceled();
        }

        #endregion
    }
}