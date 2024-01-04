#region

using Eos.Gameplay.Player.Main;
using Eos.Utils.Debug;
using Eos.Utils.System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

#endregion

namespace Eos.Gameplay.Player.Handler
{
    public class PlayerInputHandler : ITickable, IInitializable, MainControl.IPlayerActions
    {
        #region Private Variables

        [Inject] private readonly InputState      _inputState;
        [Inject] private          IMessageDisplay _messageDisplay;
        private const             int             maxDollyLevel = 3;
        private                   bool            select;

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
            mainControl.Player.Select.performed         += OnSelect;
            mainControl.Player.LookAround.performed     += OnLookAround;
            mainControl.Player.LookAround.canceled      += OnLookAround;
            mainControl.Player.MoveForward.performed    += OnMoveForward;
            mainControl.Player.MoveForward.canceled     += OnMoveForward;
            mainControl.Player.MoveHorizontal.performed += OnMoveHorizontal;
            mainControl.Player.MoveHorizontal.canceled  += OnMoveHorizontal;
            mainControl.Player.MoveVertical.performed   += OnMoveVertical;
            mainControl.Player.MoveVertical.canceled    += OnMoveVertical;

            mainControl.Player.Pointer.performed        += OnPointer;
            mainControl.Player.Pointer.canceled         += OnPointer;
            mainControl.Player.NextDollyLevel.performed += OnNextDollyLevel;
            mainControl.Player.Dodge.performed          += OnDodge;
            mainControl.Player.TurnAround.performed     += OnTurnAround;
            mainControl.Player.LockOnTarget.performed   += OnLockOnTarget;
        }

        public void Tick()
        {
            UpdateMoveDirection();
            UpdateMoveDelta();

            _inputState.SetSelect(false);

            if (select)
            {
                _inputState.SetSelect(true);
                select = false;
            }


            if (_inputState.Select)
            {
                _messageDisplay.Print("OnSelect");
            }
        }


        public void OnSelect(InputAction.CallbackContext context)
        {
            select = context.performed;
        }

        public void OnLookAround(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _inputState.SetPitchDelta(0);
                _inputState.SetYawDelta(0);
            }
            else if (context.performed)
            {
                GameplayUtils.MouseLock();
                _inputState.SetLookAround(true);
                _messageDisplay.Print("OnLookAround: " + _inputState.LookAround);
            }
            else if (context.canceled)
            {
                GameplayUtils.MouseUnlock();
                _inputState.SetLookAround(false);
                _messageDisplay.Print("OnLookAround: " + _inputState.LookAround);
            }
        }

        public void OnMoveForward(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _inputState.SetMoveForward(true);
                _messageDisplay.Print("OnMoveForward: " + _inputState.MoveForward);
            }
            else if (context.canceled)
            {
                _inputState.SetMoveForward(false);
                _messageDisplay.Print("OnMoveForward: " + _inputState.MoveForward);
            }
        }

        public void OnMoveHorizontal(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _inputState.SetMoveHorizontal(true);
                _inputState.SetHorizontal(context.ReadValue<float>());
                _messageDisplay.Print("OnMoveHorizontal: " + _inputState.MoveHorizontal);
                _messageDisplay.Print("OnHorizontal: " + _inputState.Horizontal);
            }
            else if (context.canceled)
            {
                _inputState.SetMoveHorizontal(false);
                _messageDisplay.Print("OnMoveHorizontal: " + _inputState.MoveHorizontal);
            }
        }

        public void OnMoveVertical(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _inputState.SetMoveVertical(true);
                _inputState.SetVertical(context.ReadValue<float>());
                _messageDisplay.Print("OnMoveVertical: " + _inputState.MoveVertical);
                _messageDisplay.Print("OnVertical: " + _inputState.Vertical);
            }
            else if (context.canceled)
            {
                _inputState.SetMoveVertical(false);
                _messageDisplay.Print("OnMoveVertical: " + _inputState.MoveVertical);
            }
        }

        public void OnPointer(InputAction.CallbackContext context)
        {
            if (!_inputState.LookAround) return;
            if (context.performed)
            {
                _inputState.SetMouseDelta(context.ReadValue<Vector2>());
                _messageDisplay.Print("OnPointer: " + _inputState.MouseDelta);
            }
            else if (context.canceled)
            {
                _inputState.SetMouseDelta(Vector2.zero);
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

        private void UpdateMoveDelta()
        {
            var mouseDelta = _inputState.LookAround ? _inputState.MouseDelta : Vector2.zero;
            _inputState.SetPitchDelta(mouseDelta.y);
            _inputState.SetYawDelta(mouseDelta.x);
            _inputState.SetMouseDelta(Vector2.zero);
        }

        #endregion
    }
}