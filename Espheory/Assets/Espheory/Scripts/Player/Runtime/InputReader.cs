#region

using UnityEngine.InputSystem;
using Zenject;

#endregion

namespace Espheory.Player
{
    public interface IInputReader
    {
        #region Public Methods

        bool IsSelectKeyDown();
        bool IsSelectKeyPush();

        #endregion
    }

    public class InputReader : InputMapper.IPlayerActions, IInputReader
    {
        #region Private Variables

        private          InputMapper inputMapping;
        [Inject] private IKeyTracker selectKeyTracker;

        private bool isSelectKeyDown;
        private bool isSelectKeyPush;
        private int  selectKeyDownFrame;

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
                selectKeyTracker.SetKeyDown(true);
            }

            if (context.canceled)
            {
                selectKeyTracker.SetKeyDown(false);
            }
        }

        public void OnPointer(InputAction.CallbackContext context)
        {
        }

        public bool IsSelectKeyDown()
        {
            return selectKeyTracker.IsKeyDown();
        }

        public bool IsSelectKeyPush()
        {
            return selectKeyTracker.IsKeyPush();
        }

        #endregion
    }
}