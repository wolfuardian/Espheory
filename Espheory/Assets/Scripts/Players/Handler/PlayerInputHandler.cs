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

        private readonly InputState _inputState;
        private const    int        maxDollyLevel = 3;

        #endregion


        #region Public Methods

        public void Initialize()
        {
            var mainControl = new MainControl();
            mainControl.Player.Enable();
            mainControl.Player.PitchYawDelta.performed  += OnPitchYawDelta;
            mainControl.Player.Movement.performed       += OnMovement;
            mainControl.Player.NextDollyLevel.performed += OnNextDollyLevel;
            mainControl.Player.Dodge.performed          += OnDodge;
            mainControl.Player.TurnAround.performed     += OnTurnAround;
            mainControl.Player.LockOnTarget.performed   += OnLockOnTarget;
        }

        public void Tick()
        {
        }

        public void OnPitchYawDelta(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                _inputState.SetPitchDelta(ctx.ReadValue<Vector2>().y);
                _inputState.SetYawDelta(ctx.ReadValue<Vector2>().x);
            }
        }

        public void OnMovement(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                _inputState.SetHorizontal(ctx.ReadValue<Vector2>().x);
                _inputState.SetVertical(ctx.ReadValue<Vector2>().y);
            }
        }

        public void OnNextDollyLevel(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                _inputState.SetLevelOfDolly((_inputState.LevelOfDolly + 1) % maxDollyLevel);
            }
        }

        public void OnDodge(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                _inputState.SetDodge(ctx.performed);
            }
        }

        public void OnTurnAround(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                _inputState.SetTurnAround(ctx.performed);
            }
        }

        public void OnLockOnTarget(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                _inputState.SetLockOnTarget(ctx.performed);
            }
        }

        public void OnUnlockTarget(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                _inputState.SetLockOnTarget(false);
            }
        }

        public void OnNextTarget(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _inputState.SetIndexOfTarget(_inputState.IndexOfTarget + 1);
            }
        }

        public void OnPrevTarget(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _inputState.SetIndexOfTarget(_inputState.IndexOfTarget - 1);
            }
        }

        public void OnIndexOfTarget(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                _inputState.SetIndexOfTarget((int)ctx.ReadValue<float>());
            }
        }

        #endregion


        #region Private Methods

        #endregion
    }
}