#region

using Zenject;
using UnityEngine;
using UnityEngine.InputSystem;
using Eos.Players.Main;
using Eos.Utils.Gameplay;

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
            mainControl.Player.LookAround.performed     += OnLookAround; // LOOK_AROUND
            mainControl.Player.LookAround.canceled      += OnLookAround; // 
            mainControl.Player.MoveForward.performed    += OnMoveForward; // MOVE_FORWARD
            mainControl.Player.MoveForward.canceled     += OnMoveForward; // 
            mainControl.Player.MoveHorizontal.performed += OnMoveHorizontal; // MOVE_HORIZONTAL
            mainControl.Player.MoveHorizontal.canceled  += OnMoveHorizontal; // 
            mainControl.Player.MoveVertical.performed   += OnMoveVertical; // MOVE_VERTICAL
            mainControl.Player.MoveVertical.canceled    += OnMoveVertical; // 

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
            UpdateMoveDirection();
        }

        public void OnLookAround(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                GameplayUtils.MouseLock();
                _inputState.SetLookAround(true);
            }
            else if (context.canceled)
            {
                GameplayUtils.MouseUnlock();
                _inputState.SetLookAround(false);
            }
        }

        public void OnMoveForward(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _inputState.SetMoveForward(true);
            }
            else if (context.canceled)
            {
                _inputState.SetMoveForward(false);
            }
        }

        public void OnMoveHorizontal(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _inputState.SetMoveHorizontal(true);
                _inputState.SetHorizontal(context.ReadValue<float>());
            }
            else if (context.canceled)
            {
                _inputState.SetMoveHorizontal(false);
            }
        }

        public void OnMoveVertical(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _inputState.SetMoveVertical(true);
                _inputState.SetVertical(context.ReadValue<float>());
            }
            else if (context.canceled)
            {
                _inputState.SetMoveVertical(false);
            }
        }

        public void OnPointer(InputAction.CallbackContext context)
        {
            if (!_inputState.LookAround) return;
            if (context.performed)
            {
                _inputState.SetPitchDelta(context.ReadValue<Vector2>().y);
                _inputState.SetYawDelta(context.ReadValue<Vector2>().x);
            }
            else if (context.canceled)
            {
                _inputState.SetPitchDelta(0);
                _inputState.SetYawDelta(0);
            }
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _inputState.SetHorizontal(context.ReadValue<Vector2>().x);
                _inputState.SetVertical(context.ReadValue<Vector2>().y);
            }
            else if (context.canceled)
            {
                _inputState.SetHorizontal(0);
                _inputState.SetVertical(0);
            }
        }

        public void OnNextDollyLevel(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _inputState.SetLevelOfDolly((_inputState.LevelOfDolly + 1) % maxDollyLevel);
            }
        }

        public void OnDodge(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _inputState.SetDodge(context.performed);
            }
        }

        public void OnTurnAround(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _inputState.SetTurnAround(context.performed);
            }
        }

        public void OnLockOnTarget(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _inputState.SetLockOnTarget(context.performed);
            }
        }

        public void OnUnlockTarget(InputAction.CallbackContext context)
        {
            if (context.performed)
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

        public void OnIndexOfTarget(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _inputState.SetIndexOfTarget((int)context.ReadValue<float>());
            }
        }

        #endregion


        #region Private Methods

        private void UpdateMoveDirection()
        {
            var moveDirection = _inputState.MoveForward ? Vector2.up : Vector2.zero;
            moveDirection += _inputState.MoveHorizontal ? Vector2.right * _inputState.Horizontal : Vector2.zero;
            moveDirection += _inputState.MoveVertical ? Vector2.up * _inputState.Vertical : Vector2.zero;
            moveDirection =  moveDirection.normalized;
            _inputState.SetMoveDirection(moveDirection);
        }

        #endregion
    }
}