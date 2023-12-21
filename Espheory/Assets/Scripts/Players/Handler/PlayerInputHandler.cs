#region

using Eos.Players.Main;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

#endregion

namespace Eos.Players.Handler
{
    public class PlayerInputHandler : ITickable, IInitializable
    {
        #region Private Variables

        [Inject] private PlayerInputState inputState;

        #endregion


        #region Public Methods

        public void Initialize()
        {
            var mainControl = new MainControl();
            mainControl.Player.Enable();
            mainControl.Player.Dodge.performed += OnDodge;
        }

        public void Tick()
        {
        }

        #endregion


        #region Private Methods

        private void OnDodge(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                inputState.SetDodge(true);
            }
            else if (context.canceled)
            {
                inputState.SetDodge(false);
            }
        }

        #endregion
    }
}