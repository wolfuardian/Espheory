#region

using Zenject;
using UnityEngine;
using UnityEngine.InputSystem;
using Eos.Players.Main;

#endregion

namespace Eos.Players.Handler
{
    public class PlayerInputHandler : ITickable, IInitializable, MainControl.IPlayerActions
    {
        #region Private Variables

        [Inject] private PlayerInputState inputState;
        private          int              levelOfDolly;
        private const    int              MaxDollyLevel = 3;

        #endregion


        #region Public Methods

        public void Tick()
        {
        }

        public void Initialize()
        {
            var mainControl = new MainControl();
            mainControl.Player.Enable();
            mainControl.Player.PitchYaw.performed       += OnPitchYaw;
            mainControl.Player.Movement.performed       += OnMovement;
            mainControl.Player.NextDollyLevel.performed += OnNextDollyLevel;
            mainControl.Player.Dodge.performed          += OnDodge;
            mainControl.Player.TurnAround.performed     += OnTurnAround;
            mainControl.Player.LockOnTarget.performed   += OnLockOnTarget;
        }

        public void OnPitchYaw(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                inputState.SetPitch(ctx.ReadValue<Vector2>().y);
                inputState.SetYaw(ctx.ReadValue<Vector2>().x);
            }
        }

        public void OnMovement(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                inputState.SetHorizontal(ctx.ReadValue<Vector2>().x);
                inputState.SetVertical(ctx.ReadValue<Vector2>().y);
            }
        }

        public void OnNextDollyLevel(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                inputState.SetLevelOfDolly(levelOfDolly + 1);
            }
        }

        public void OnDodge(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                inputState.SetDodge(ctx.performed);
            }
        }

        public void OnTurnAround(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                inputState.SetTurnAround(ctx.performed);
            }
        }

        public void OnLockOnTarget(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                inputState.SetLockOnTarget(ctx.performed);
            }
        }

        public void OnUnlockTarget(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                inputState.SetLockOnTarget(false);
            }
        }

        public void OnNextTarget(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                inputState.SetIndexOfTarget(inputState.IndexOfTarget + 1);
            }
        }

        public void OnPrevTarget(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                inputState.SetIndexOfTarget(inputState.IndexOfTarget - 1);
            }
        }

        public void OnIndexOfTarget(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                inputState.SetIndexOfTarget((int)ctx.ReadValue<float>());
            }
        }

        #endregion


        #region Private Methods

        #endregion
    }
}