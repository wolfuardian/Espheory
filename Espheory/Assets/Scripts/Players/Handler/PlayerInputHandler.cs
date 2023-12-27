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

        public PlayerInputHandler(InputState inputState)
        {
            _inputState = inputState;
        }

        public void Initialize()
        {
            var mainControl = new MainControl();
            mainControl.Player.Enable();
            mainControl.Player.LookAround.performed     += OnLookAround;
            mainControl.Player.LookAround.canceled      += OnLookAround;
            mainControl.Player.Pointer.performed        += OnPointer;
            mainControl.Player.Pointer.canceled         += OnPointer;
            mainControl.Player.Movement.performed       += OnMovement;
            mainControl.Player.Movement.canceled        += OnMovement;
            mainControl.Player.NextDollyLevel.performed += OnNextDollyLevel;
            mainControl.Player.Dodge.performed          += OnDodge;
            mainControl.Player.TurnAround.performed     += OnTurnAround;
            mainControl.Player.LockOnTarget.performed   += OnLockOnTarget;
        }

        public void Tick()
        {
        }

        public void OnLookAround(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
                _inputState.SetLookAround(true);
            else if (ctx.canceled)
                _inputState.SetLookAround(false);
        }

        public void OnPointer(InputAction.CallbackContext ctx)
        {
            if (!_inputState.LookAround) return;
            if (ctx.performed)
            {
                _inputState.SetPitchDelta(ctx.ReadValue<Vector2>().y);
                _inputState.SetYawDelta(ctx.ReadValue<Vector2>().x);
            }
            else if (ctx.canceled)
            {
                _inputState.SetPitchDelta(0);
                _inputState.SetYawDelta(0);
            }
        }

        public void OnMovement(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                _inputState.SetHorizontal(ctx.ReadValue<Vector2>().x);
                _inputState.SetVertical(ctx.ReadValue<Vector2>().y);
            }
            else if (ctx.canceled)
            {
                _inputState.SetHorizontal(0);
                _inputState.SetVertical(0);
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