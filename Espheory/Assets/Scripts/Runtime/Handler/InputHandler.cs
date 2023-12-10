using UnityEngine;
using Eos.Runtime.Core;
using Eos.Runtime.Interface;
using Eos.Events.ScriptableObjects;

namespace Eos.Runtime.Handler
{
    public class InputHandler : MonoBehaviour, ITick
    {
        [Header("Broadcasting on")] [SerializeField]
        private MouseEventChannelSO onMouseEventChannel;

        public Vector3 mousePosition => Input.mousePosition;
        public Vector2 mouseMoveDelta => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        public Vector2 mouseScrollDelta => Input.mouseScrollDelta;
        public bool isUpdateHandlerIsNull => UpdateHandler.instance == null;
        public bool isLeftMouseButtonHold => Input.GetMouseButton(0);
        public bool isLeftMouseButtonPress => Input.GetMouseButtonDown(0);
        public bool isLeftMouseButtonRelease => Input.GetMouseButtonUp(0);
        public bool isRightMouseButtonHold => Input.GetMouseButton(1);
        public bool isRightMouseButtonPress => Input.GetMouseButtonDown(1);
        public bool isRightMouseButtonRelease => Input.GetMouseButtonUp(1);
        public bool isMiddleMouseButtonHold => Input.GetMouseButton(2);
        public bool isMiddleMouseButtonPress => Input.GetMouseButtonDown(2);
        public bool isMiddleMouseButtonRelease => Input.GetMouseButtonUp(2);
        public bool isMouseMoving => mouseMoveDelta != Vector2.zero;
        public bool isMouseScrolling => mouseScrollDelta.y != 0;
        public bool isLeftMouseButtonDragging => isLeftMouseButtonHold && isMouseMoving;
        public bool isRightMouseButtonDragging => isRightMouseButtonHold && isMouseMoving;
        public bool isMiddleMouseButtonDragging => isMiddleMouseButtonHold && isMouseMoving;
        public Vector2 leftMouseButtonDragOffset => (Vector2)mousePosition - _leftMouseButtonDragOrigin;
        public Vector2 rightMouseButtonDragOffset => (Vector2)mousePosition - _rightMouseButtonDragOrigin;
        public Vector2 middleMouseButtonDragOffset => (Vector2)mousePosition - _middleMouseButtonDragOrigin;
        public bool isShiftKeyPressed => Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        private int _leftMouseButtonHoldFrames;
        private int _middleMouseButtonHoldFrames;
        private int _rightMouseButtonHoldFrames;
        private Vector2 _leftMouseButtonDragOrigin;
        private Vector2 _middleMouseButtonDragOrigin;
        private Vector2 _rightMouseButtonDragOrigin;

        private void Start()
        {
            if (isUpdateHandlerIsNull) return;
            UpdateHandler.instance.Register(this);
        }

        private void OnDestroy()
        {
            if (isUpdateHandlerIsNull) return;
            UpdateHandler.instance.Unregister(this);
        }

        public void Tick()
        {
            if (isLeftMouseButtonPress) OnLeftMouseButtonPressed();

            if (isLeftMouseButtonRelease) OnLeftMouseButtonReleased();

            if (isLeftMouseButtonHold) OnLeftMouseButtonHold();

            if (isMiddleMouseButtonPress) OnMiddleMouseButtonPressed();

            if (isMiddleMouseButtonRelease) OnMiddleMouseButtonReleased();

            if (isMiddleMouseButtonHold) OnMiddleMouseButtonHold();

            if (isRightMouseButtonPress) OnRightMouseButtonPressed();

            if (isRightMouseButtonRelease) OnRightMouseButtonReleased();

            if (isRightMouseButtonHold) OnRightMouseButtonHold();

            if (isMouseMoving) OnMouseMoving();

            if (isMouseScrolling) OnMouseScrolling();

            if (isLeftMouseButtonDragging) OnLeftMouseButtonDragging();

            if (isRightMouseButtonDragging) OnRightMouseButtonDragging();

            if (isMiddleMouseButtonDragging) OnMiddleMouseButtonDragging();
        }

        private void OnLeftMouseButtonPressed()
        {
            onMouseEventChannel.RaiseLMBPressEvent();
            _leftMouseButtonDragOrigin = mousePosition;
        }

        private void OnLeftMouseButtonReleased()
        {
            onMouseEventChannel.RaiseLMBReleaseEvent();
            _leftMouseButtonHoldFrames = 0;
            onMouseEventChannel.RaiseLMBDragEvent(Vector2.zero);
        }

        private void OnLeftMouseButtonHold()
        {
            onMouseEventChannel.RaiseLMBHoldEvent();
            _leftMouseButtonHoldFrames++;
            onMouseEventChannel.RaiseLMBHoldFramesEvent(_leftMouseButtonHoldFrames);
        }

        private void OnMiddleMouseButtonPressed()
        {
            onMouseEventChannel.RaiseMMBPressEvent();
            _middleMouseButtonDragOrigin = mousePosition;
        }

        private void OnMiddleMouseButtonReleased()
        {
            onMouseEventChannel.RaiseMMBReleaseEvent();
            _middleMouseButtonHoldFrames = 0;
            onMouseEventChannel.RaiseMMBDragEvent(Vector2.zero);
        }

        private void OnMiddleMouseButtonHold()
        {
            onMouseEventChannel.RaiseMMBHoldEvent();
            _middleMouseButtonHoldFrames++;
            onMouseEventChannel.RaiseMMBHoldFramesEvent(_middleMouseButtonHoldFrames);
        }

        private void OnRightMouseButtonPressed()
        {
            onMouseEventChannel.RaiseRMBPressEvent();
            _rightMouseButtonDragOrigin = mousePosition;
        }

        private void OnRightMouseButtonReleased()
        {
            onMouseEventChannel.RaiseRMBReleaseEvent();
            _rightMouseButtonHoldFrames = 0;
            onMouseEventChannel.RaiseRMBDragEvent(Vector2.zero);
        }

        private void OnRightMouseButtonHold()
        {
            onMouseEventChannel.RaiseRMBHoldEvent();
            _rightMouseButtonHoldFrames++;
            onMouseEventChannel.RaiseRMBHoldFramesEvent(_rightMouseButtonHoldFrames);
        }

        private void OnMouseMoving()
        {
            onMouseEventChannel.RaiseMousePositionEvent(mousePosition);
            onMouseEventChannel.RaiseMouseMoveDeltaEvent(mouseMoveDelta);
        }

        private void OnMouseScrolling()
        {
            onMouseEventChannel.RaiseMouseScrollDeltaEvent(mouseScrollDelta.y);
        }

        private void OnLeftMouseButtonDragging()
        {
            onMouseEventChannel.RaiseLMBDragEvent(leftMouseButtonDragOffset);
        }

        private void OnMiddleMouseButtonDragging()
        {
            onMouseEventChannel.RaiseMMBDragEvent(middleMouseButtonDragOffset);
        }

        private void OnRightMouseButtonDragging()
        {
            onMouseEventChannel.RaiseRMBDragEvent(rightMouseButtonDragOffset);
        }
    }
}