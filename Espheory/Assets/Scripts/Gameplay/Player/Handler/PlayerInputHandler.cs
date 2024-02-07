#region

using Eos.Gameplay.Input;
using Zenject;
using UnityEngine;
using Eos.Utils.Debug;
using Eos.Utils.System;
using UnityEngine.InputSystem;
using Eos.Gameplay.Player.Main;

#endregion

namespace Eos.Gameplay.Player.Handler
{
    public class PlayerInputHandler : ITickable, IInitializable, MainControl.IPlayerActions
    {
        #region Private Variables

        [Inject] private readonly InputState      m_InputState;
        [Inject] private          IMessageDisplay m_MessageDisplay;
        private const             int             maxDollyLevel = 3;
        private                   bool            m_Select;

        #endregion


        #region Public Methods

        public PlayerInputHandler(InputState inputState)
        {
            m_InputState = inputState;
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

            mainControl.Player.PointerDelta.performed    += OnPointerDelta;
            mainControl.Player.PointerDelta.canceled     += OnPointerDelta;
            mainControl.Player.PointerPosition.performed += OnPointerPosition;
            mainControl.Player.NextDollyLevel.performed  += OnNextDollyLevel;
            mainControl.Player.Dodge.performed           += OnDodge;
            mainControl.Player.TurnAround.performed      += OnTurnAround;
            mainControl.Player.LockOnTarget.performed    += OnLockOnTarget;
        }

        public void Tick()
        {
            UpdateMoveDirection();
            UpdateMoveDelta();

            m_InputState.SetSelect(false);

            if (m_Select)
            {
                m_InputState.SetSelect(true);
                m_Select = false;
            }


            if (m_InputState.Select)
            {
                m_MessageDisplay.Print("OnSelect");
            }
        }


        public void OnSelect(InputAction.CallbackContext context)
        {
            m_Select = context.performed;
        }

        public void OnLookAround(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                m_InputState.SetPitchDelta(0);
                m_InputState.SetYawDelta(0);
            }
            else if (context.performed)
            {
                GameplayUtils.MouseLock();
                m_InputState.SetLookAround(true);
                m_MessageDisplay.Print("OnLookAround: " + m_InputState.LookAround);
            }
            else if (context.canceled)
            {
                GameplayUtils.MouseUnlock();
                m_InputState.SetLookAround(false);
                m_MessageDisplay.Print("OnLookAround: " + m_InputState.LookAround);
            }
        }

        public void OnMoveForward(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_InputState.SetMoveForward(true);
                m_MessageDisplay.Print("OnMoveForward: " + m_InputState.MoveForward);
            }
            else if (context.canceled)
            {
                m_InputState.SetMoveForward(false);
                m_MessageDisplay.Print("OnMoveForward: " + m_InputState.MoveForward);
            }
        }

        public void OnMoveHorizontal(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_InputState.SetMoveHorizontal(true);
                m_InputState.SetHorizontal(context.ReadValue<float>());
                m_MessageDisplay.Print("OnMoveHorizontal: " + m_InputState.MoveHorizontal);
                m_MessageDisplay.Print("OnHorizontal: " + m_InputState.Horizontal);
            }
            else if (context.canceled)
            {
                m_InputState.SetMoveHorizontal(false);
                m_MessageDisplay.Print("OnMoveHorizontal: " + m_InputState.MoveHorizontal);
            }
        }

        public void OnMoveVertical(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_InputState.SetMoveVertical(true);
                m_InputState.SetVertical(context.ReadValue<float>());
                m_MessageDisplay.Print("OnMoveVertical: " + m_InputState.MoveVertical);
                m_MessageDisplay.Print("OnVertical: " + m_InputState.Vertical);
            }
            else if (context.canceled)
            {
                m_InputState.SetMoveVertical(false);
                m_MessageDisplay.Print("OnMoveVertical: " + m_InputState.MoveVertical);
            }
        }

        public void OnPointerDelta(InputAction.CallbackContext context)
        {
            if (!m_InputState.LookAround) return;
            if (context.performed)
            {
                m_InputState.SetMouseDelta(context.ReadValue<Vector2>());
                m_MessageDisplay.Print("OnPointer: " + m_InputState.MouseDelta);
            }
            else if (context.canceled)
            {
                m_InputState.SetMouseDelta(Vector2.zero);
            }
        }

        public void OnPointerPosition(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_InputState.SetPointerPosition(context.ReadValue<Vector2>());
                m_MessageDisplay.Print("OnPointerPosition: " + m_InputState.PointerPosition);
            }
        }

        public void OnNextDollyLevel(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_InputState.SetLevelOfDolly((m_InputState.LevelOfDolly + 1) % maxDollyLevel);
            }
        }

        public void OnDodge(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_InputState.SetDodge(context.performed);
            }
        }

        public void OnTurnAround(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_InputState.SetTurnAround(context.performed);
            }
        }

        public void OnLockOnTarget(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_InputState.SetLockOnTarget(context.performed);
            }
        }

        public void OnUnlockTarget(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_InputState.SetLockOnTarget(false);
            }
        }

        public void OnNextTarget(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_InputState.SetIndexOfTarget(m_InputState.IndexOfTarget + 1);
            }
        }

        public void OnPrevTarget(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_InputState.SetIndexOfTarget(m_InputState.IndexOfTarget - 1);
            }
        }

        public void OnIndexOfTarget(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_InputState.SetIndexOfTarget((int)context.ReadValue<float>());
            }
        }

        #endregion


        #region Private Methods

        private void UpdateMoveDirection()
        {
            var moveDirection = m_InputState.MoveForward ? Vector2.up : Vector2.zero;
            moveDirection += m_InputState.MoveHorizontal ? Vector2.right * m_InputState.Horizontal : Vector2.zero;
            moveDirection += m_InputState.MoveVertical ? Vector2.up * m_InputState.Vertical : Vector2.zero;
            moveDirection =  moveDirection.normalized;
            m_InputState.SetMoveDirection(moveDirection);
        }

        private void UpdateMoveDelta()
        {
            var mouseDelta = m_InputState.LookAround ? m_InputState.MouseDelta : Vector2.zero;
            m_InputState.SetPitchDelta(mouseDelta.y);
            m_InputState.SetYawDelta(mouseDelta.x);
            m_InputState.SetMouseDelta(Vector2.zero);
        }

        #endregion
    }
}