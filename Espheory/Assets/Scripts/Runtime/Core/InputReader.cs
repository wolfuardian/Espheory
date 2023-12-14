using Eos.Runtime.Events.ScriptableObjects;
using UnityEngine;

namespace Eos.Runtime.Core
{
    public class InputReader : ModuleBase
    {
        [Header("Broadcasting on")] [SerializeField]
        private MouseEventChannelSO mouseEventChannel;

        public Vector3 mousePosition => Input.mousePosition;
        public Vector2 mouseMoveDelta => new(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        public Vector2 mouseScrollDelta => Input.mouseScrollDelta;
        public bool updateHandlerExists => PersistentManager.instance != null;
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
            PersistentManager.instance.Register(this);
        }

        private void OnDestroy()
        {
            if (mouseEventChannel == null) return;

            if (!updateHandlerExists) return;
            PersistentManager.instance.Unregister(this);
        }

        public override void Tick()
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
            mouseEventChannel.RaiseLeftMouseButtonDragOffset(Vector2.zero);
        }

        private void OnLeftMouseButtonHeld()
        {
            mouseEventChannel.RaiseLeftMouseButtonHoldEvent();
            _leftMouseButtonHoldFrames++;
            mouseEventChannel.RaiseLeftMouseButtonHoldFramesEvent(_leftMouseButtonHoldFrames);
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
            mouseEventChannel.RaiseRightMouseButtonDragOffset(Vector2.zero);
        }

        private void OnRightMouseButtonHeld()
        {
            mouseEventChannel.RaiseRightMouseButtonHoldEvent();
            _rightMouseButtonHoldFrames++;
            mouseEventChannel.RaiseRightMouseButtonHoldFramesEvent(_rightMouseButtonHoldFrames);
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
            mouseEventChannel.RaiseMiddleMouseButtonDragOffset(Vector2.zero);
        }

        private void OnMiddleMouseButtonHeld()
        {
            mouseEventChannel.RaiseMiddleMouseButtonHoldEvent();
            _middleMouseButtonHoldFrames++;
            mouseEventChannel.RaiseMiddleMouseButtonHoldFramesEvent(_middleMouseButtonHoldFrames);
        }

        private void OnLeftMouseButtonDragging()
        {
            mouseEventChannel.RaiseLeftMouseButtonDrag();
            mouseEventChannel.RaiseLeftMouseButtonDragOffset(leftMouseButtonDragOffset);
        }

        private void OnRightMouseButtonDragging()
        {
            mouseEventChannel.RaiseRightMouseButtonDrag();
            mouseEventChannel.RaiseRightMouseButtonDragOffset(rightMouseButtonDragOffset);
        }

        private void OnMiddleMouseButtonDragging()
        {
            mouseEventChannel.RaiseMiddleMouseButtonDrag();
            mouseEventChannel.RaiseMiddleMouseButtonDragOffset(middleMouseButtonDragOffset);
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