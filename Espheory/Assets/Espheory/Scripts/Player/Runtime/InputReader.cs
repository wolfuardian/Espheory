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

    public class InputReader : InputMapper.IPlayerActions, IInputReader
    {
        #region Private Variables

        private InputMapper inputMapping;

        [Inject] private IKey selectKey;

        private bool isSelectKeyStarted;
        private bool isSelectKeyPerformed;
        private bool isSelectKeyCanceled;

        #endregion

        #region Public Methods

        [Inject]
        public void Construct()
        {
            inputMapping = new InputMapper();
            inputMapping.Player.SetCallbacks(this);
            inputMapping.Player.Enable();
        }

        public void OnSelect(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                // TODO: This could be the entry point for verifying logic.
            }
            
            if (context.performed)
            {
                selectKey.SetKeyPerformed();
            }

            if (context.canceled)
            {
                selectKey.SetKeyCanceled();
            }
        }

        public void OnPointer(InputAction.CallbackContext context)
        {
            // TODO: This will serve as the logic code for the cursor on the screen.
        }

        public bool IsSelectKeyStarted()
        {
            return selectKey.IsKeyStarted();
        }

        public bool IsSelectKeyPerformed()
        {
            return selectKey.IsKeyPerformed();
        }

        public bool IsSelectKeyCanceled()
        {
            return selectKey.IsKeyCanceled();
        }

        #endregion
    }
}