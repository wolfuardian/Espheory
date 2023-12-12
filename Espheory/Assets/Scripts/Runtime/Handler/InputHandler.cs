using System;
using UnityEngine;
using Eos.Runtime.Core;
using Eos.Runtime.Interface;
using Eos.Events.ScriptableObjects;

namespace Eos.Runtime.Handler
{
    public class InputHandler : MonoBehaviour, ITick
    {
        [Header("Broadcasting on")] [SerializeField]
        private MouseEventChannelSO mouseEventChannel;

        public Vector3 mousePosition => Input.mousePosition;
        public Vector2 mouseMoveDelta => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        public Vector2 mouseScrollDelta => Input.mouseScrollDelta;
        public bool updateHandlerExists => UpdateHandler.instance != null;
        public bool isLeftMouseButtonHolding => Input.GetMouseButton(0);
        public bool isLeftMouseButtonPressing => Input.GetMouseButtonDown(0);
        public bool isLeftMouseButtonReleasing => Input.GetMouseButtonUp(0);
        public bool isRightMouseButtonHolding => Input.GetMouseButton(1);
        public bool isRightMouseButtonPressing => Input.GetMouseButtonDown(1);
        public bool isRightMouseButtonReleasing => Input.GetMouseButtonUp(1);
        public bool isMiddleMouseButtonHolding => Input.GetMouseButton(2);
        public bool isMiddleMouseButtonPressing => Input.GetMouseButtonDown(2);
        public bool isMiddleMouseButtonReleasing => Input.GetMouseButtonUp(2);
        public bool isMouseMoving => mouseMoveDelta != Vector2.zero;
        public bool isMouseScrolling => mouseScrollDelta.y != 0;
        public bool isLeftMouseButtonDragging => isLeftMouseButtonHolding && isMouseMoving;
        public bool isRightMouseButtonDragging => isRightMouseButtonHolding && isMouseMoving;
        public bool isMiddleMouseButtonDragging => isMiddleMouseButtonHolding && isMouseMoving;
        public Vector2 leftMouseButtonDragOffset => (Vector2)mousePosition - _leftMouseButtonDragOrigin;
        public Vector2 rightMouseButtonDragOffset => (Vector2)mousePosition - _rightMouseButtonDragOrigin;
        public Vector2 middleMouseButtonDragOffset => (Vector2)mousePosition - _middleMouseButtonDragOrigin;
        public bool isShiftKeyPressed => Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        private int _leftMouseButtonHoldFrames;
        private int _rightMouseButtonHoldFrames;
        private int _middleMouseButtonHoldFrames;
        private Vector2 _leftMouseButtonDragOrigin;
        private Vector2 _rightMouseButtonDragOrigin;
        private Vector2 _middleMouseButtonDragOrigin;

        private void Start()
        {
            if (mouseEventChannel == null)
            {
                Debug.Log("Mouse Event Channel is null", this);
                return;
            }

            if (!updateHandlerExists) return;
            UpdateHandler.instance.Register(this);
        }

        private void OnDestroy()
        {
            if (mouseEventChannel == null) return;

            if (!updateHandlerExists) return;
            UpdateHandler.instance.Unregister(this);
        }

        public void Tick()
        {
            if (mouseEventChannel == null) return;

            if (isLeftMouseButtonPressing) OnLeftMouseButtonPressed();

            if (isLeftMouseButtonReleasing) OnLeftMouseButtonReleased();

            if (isLeftMouseButtonHolding) OnLeftMouseButtonHeld();

            if (isRightMouseButtonPressing) OnRightMouseButtonPressed();

            if (isRightMouseButtonReleasing) OnRightMouseButtonReleased();

            if (isRightMouseButtonHolding) OnRightMouseButtonHeld();

            if (isMiddleMouseButtonPressing) OnMiddleMouseButtonPressed();

            if (isMiddleMouseButtonReleasing) OnMiddleMouseButtonReleased();

            if (isMiddleMouseButtonHolding) OnMiddleMouseButtonHeld();

            if (isLeftMouseButtonDragging) OnLeftMouseButtonDragging();

            if (isRightMouseButtonDragging) OnRightMouseButtonDragging();

            if (isMiddleMouseButtonDragging) OnMiddleMouseButtonDragging();

            if (isMouseMoving) OnMouseMoved();

            if (isMouseScrolling) OnMouseScrolled();
        }

        private void OnLeftMouseButtonPressed()
        {
            mouseEventChannel.RaiseLeftMouseButtonPressEvent();
            _leftMouseButtonDragOrigin = mousePosition;
        }

        private void OnLeftMouseButtonReleased()
        {
            mouseEventChannel.RaiseLeftMouseButtonReleaseEvent();
            _leftMouseButtonHoldFrames = 0;
            mouseEventChannel.RaiseLeftMouseButtonDragEvent(Vector2.zero);
        }

        private void OnLeftMouseButtonHeld()
        {
            mouseEventChannel.RaiseLeftMouseButtonHoldEvent();
            _leftMouseButtonHoldFrames++;
            mouseEventChannel.RaiseLeftMouseButtonHoldFramesEvent(_leftMouseButtonHoldFrames);
        }

        private void OnMiddleMouseButtonPressed()
        {
            mouseEventChannel.RaiseMiddleMouseButtonPressEvent();
            _middleMouseButtonDragOrigin = mousePosition;
        }

        private void OnMiddleMouseButtonReleased()
        {
            mouseEventChannel.RaiseMiddleMouseButtonReleaseEvent();
            _middleMouseButtonHoldFrames = 0;
            mouseEventChannel.RaiseMiddleMouseButtonDragEvent(Vector2.zero);
        }

        private void OnMiddleMouseButtonHeld()
        {
            mouseEventChannel.RaiseMiddleMouseButtonHoldEvent();
            _middleMouseButtonHoldFrames++;
            mouseEventChannel.RaiseMiddleMouseButtonHoldFramesEvent(_middleMouseButtonHoldFrames);
        }

        private void OnRightMouseButtonPressed()
        {
            mouseEventChannel.RaiseRightMouseButtonPressEvent();
            _rightMouseButtonDragOrigin = mousePosition;
        }

        private void OnRightMouseButtonReleased()
        {
            mouseEventChannel.RaiseRightMouseButtonReleaseEvent();
            _rightMouseButtonHoldFrames = 0;
            mouseEventChannel.RaiseRightMouseButtonDragEvent(Vector2.zero);
        }

        private void OnRightMouseButtonHeld()
        {
            mouseEventChannel.RaiseRightMouseButtonHoldEvent();
            _rightMouseButtonHoldFrames++;
            mouseEventChannel.RaiseRightMouseButtonHoldFramesEvent(_rightMouseButtonHoldFrames);
        }

        private void OnLeftMouseButtonDragging()
        {
            mouseEventChannel.RaiseLeftMouseButtonDragEvent(leftMouseButtonDragOffset);
        }

        private void OnMiddleMouseButtonDragging()
        {
            mouseEventChannel.RaiseMiddleMouseButtonDragEvent(middleMouseButtonDragOffset);
        }

        private void OnRightMouseButtonDragging()
        {
            mouseEventChannel.RaiseRightMouseButtonDragEvent(rightMouseButtonDragOffset);
        }

        private void OnMouseMoved()
        {
            mouseEventChannel.RaiseMousePositionEvent(mousePosition);
            mouseEventChannel.RaiseMouseMoveDeltaEvent(mouseMoveDelta);
        }

        private void OnMouseScrolled()
        {
            mouseEventChannel.RaiseScrollEvent();
            mouseEventChannel.RaiseMouseScrollDeltaEvent(mouseScrollDelta.y);
        }
    }
}