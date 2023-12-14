using Eos.Runtime.Events.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Eos.Runtime.Mouse
{
    public class MouseEventListener : MonoBehaviour
    {
        [Header("Listening to")] [SerializeField]
        private MouseEventChannelSO mouseEventChannel;

        [Header("UnityEvent Response")] [SerializeField]
        private UnityEvent<bool> onLeftMouseButtonPress;

        [SerializeField] private UnityEvent<bool> onRightMouseButtonPress;
        [SerializeField] private UnityEvent<bool> onMiddleMouseButtonPress;
        [SerializeField] private UnityEvent<bool> onScroll;
        [SerializeField] private UnityEvent<bool> onScrollUp;
        [SerializeField] private UnityEvent<bool> onScrollDown;
        [SerializeField] private UnityEvent onLeftMouseButtonHold;
        [SerializeField] private UnityEvent onRightMouseButtonHold;
        [SerializeField] private UnityEvent onMiddleMouseButtonHold;
        [SerializeField] private UnityEvent<float> onLeftMouseButtonHoldFrames;
        [SerializeField] private UnityEvent<float> onRightMouseButtonHoldFrames;
        [SerializeField] private UnityEvent<float> onMiddleMouseButtonHoldFrames;
        [SerializeField] private UnityEvent<float> onMousePositionX;
        [SerializeField] private UnityEvent<float> onMousePositionY;
        [SerializeField] private UnityEvent<float> onMouseMoveDeltaX;
        [SerializeField] private UnityEvent<float> onMouseMoveDeltaY;
        [SerializeField] private UnityEvent<float> onMouseScrollDelta;
        [SerializeField] private UnityEvent<float> onLeftMouseButtonDragX;
        [SerializeField] private UnityEvent<float> onLeftMouseButtonDragY;
        [SerializeField] private UnityEvent<float> onRightMouseButtonDragX;
        [SerializeField] private UnityEvent<float> onRightMouseButtonDragY;
        [SerializeField] private UnityEvent<float> onMiddleMouseButtonDragX;
        [SerializeField] private UnityEvent<float> onMiddleMouseButtonDragY;

        private void OnEnable()
        {
            mouseEventChannel.onLeftMouseButtonPress += OnLeftMouseButtonPressed;
            mouseEventChannel.onLeftMouseButtonRelease += OnLeftMouseButtonReleased;
            mouseEventChannel.onLeftMouseButtonHold += OnLeftMouseButtonHold;
            mouseEventChannel.onMiddleMouseButtonPress += OnMiddleMouseButtonPressed;
            mouseEventChannel.onMiddleMouseButtonRelease += OnMiddleMouseButtonReleased;
            mouseEventChannel.onMiddleMouseButtonHold += OnMiddleMouseButtonHold;
            mouseEventChannel.onRightMouseButtonPress += OnRightMouseButtonPressed;
            mouseEventChannel.onRightMouseButtonRelease += OnRightMouseButtonReleased;
            mouseEventChannel.onRightMouseButtonHold += OnRightMouseButtonHold;
            mouseEventChannel.onScroll += OnScrolling;
            mouseEventChannel.onLeftMouseButtonHoldFrames += OnLMBHoldFrames;
            mouseEventChannel.onMiddleMouseButtonHoldFrames += OnMMBHoldFrames;
            mouseEventChannel.onRightMouseButtonHoldFrames += OnRMBHoldFrames;
            mouseEventChannel.onMousePosition += OnMousePosition;
            mouseEventChannel.onMouseMoveDelta += OnMouseMoveDelta;
            mouseEventChannel.onMouseScrollDelta += OnMouseScrollDelta;
            mouseEventChannel.onLeftMouseButtonDragOffset += OnLMBDrag;
            mouseEventChannel.onRightMouseButtonDragOffset += OnRMBDrag;
            mouseEventChannel.onMiddleMouseButtonDragOffset += OnMMBDrag;
        }

        private void OnDisable()
        {
            mouseEventChannel.onLeftMouseButtonPress -= OnLeftMouseButtonPressed;
            mouseEventChannel.onLeftMouseButtonRelease -= OnLeftMouseButtonReleased;
            mouseEventChannel.onLeftMouseButtonHold -= OnLeftMouseButtonHold;
            mouseEventChannel.onMiddleMouseButtonPress -= OnMiddleMouseButtonPressed;
            mouseEventChannel.onMiddleMouseButtonRelease -= OnMiddleMouseButtonReleased;
            mouseEventChannel.onMiddleMouseButtonHold -= OnMiddleMouseButtonHold;
            mouseEventChannel.onRightMouseButtonPress -= OnRightMouseButtonPressed;
            mouseEventChannel.onRightMouseButtonRelease -= OnRightMouseButtonReleased;
            mouseEventChannel.onRightMouseButtonHold -= OnRightMouseButtonHold;
            mouseEventChannel.onScroll -= OnScrolling;
            mouseEventChannel.onLeftMouseButtonHoldFrames -= OnLMBHoldFrames;
            mouseEventChannel.onMiddleMouseButtonHoldFrames -= OnMMBHoldFrames;
            mouseEventChannel.onRightMouseButtonHoldFrames -= OnRMBHoldFrames;
            mouseEventChannel.onMousePosition -= OnMousePosition;
            mouseEventChannel.onMouseMoveDelta -= OnMouseMoveDelta;
            mouseEventChannel.onMouseScrollDelta -= OnMouseScrollDelta;
            mouseEventChannel.onLeftMouseButtonDragOffset -= OnLMBDrag;
            mouseEventChannel.onRightMouseButtonDragOffset -= OnRMBDrag;
            mouseEventChannel.onMiddleMouseButtonDragOffset -= OnMMBDrag;
        }

        private void OnLeftMouseButtonPressed()
        {
            onLeftMouseButtonPress?.Invoke(true);
        }

        private void OnLeftMouseButtonReleased()
        {
            onLeftMouseButtonPress?.Invoke(false);
            onLeftMouseButtonHoldFrames?.Invoke(0);
        }

        private void OnLeftMouseButtonHold()
        {
            onLeftMouseButtonHold?.Invoke();
        }

        private void OnRightMouseButtonPressed()
        {
            onRightMouseButtonPress?.Invoke(true);
        }

        private void OnRightMouseButtonReleased()
        {
            onRightMouseButtonPress?.Invoke(false);
            onRightMouseButtonHoldFrames?.Invoke(0);
        }

        private void OnRightMouseButtonHold()
        {
            onRightMouseButtonHold?.Invoke();
        }

        private void OnScrolling()
        {
            onScroll?.Invoke(true);
            onScrollUp?.Invoke(Input.mouseScrollDelta.y > 0);
            onScrollDown?.Invoke(Input.mouseScrollDelta.y < 0);
        }

        private void OnMiddleMouseButtonPressed()
        {
            onMiddleMouseButtonPress?.Invoke(true);
        }

        private void OnMiddleMouseButtonReleased()
        {
            onMiddleMouseButtonPress?.Invoke(false);
            onMiddleMouseButtonHoldFrames?.Invoke(0);
        }

        private void OnMiddleMouseButtonHold()
        {
            onMiddleMouseButtonHold?.Invoke();
        }

        private void OnLMBHoldFrames(int value)
        {
            onLeftMouseButtonHoldFrames?.Invoke(value);
        }

        private void OnRMBHoldFrames(int value)
        {
            onRightMouseButtonHoldFrames?.Invoke(value);
        }

        private void OnMMBHoldFrames(int value)
        {
            onMiddleMouseButtonHoldFrames?.Invoke(value);
        }

        private void OnMousePosition(Vector2 value)
        {
            onMousePositionX?.Invoke(value.x);
            onMousePositionY?.Invoke(value.y);
        }

        private void OnMouseMoveDelta(Vector2 value)
        {
            onMouseMoveDeltaX?.Invoke(value.x);
            onMouseMoveDeltaY?.Invoke(value.y);
        }

        private void OnMouseScrollDelta(float value)
        {
            onMouseScrollDelta?.Invoke(value);
        }

        private void OnLMBDrag(Vector2 value)
        {
            onLeftMouseButtonDragX?.Invoke(value.x);
            onLeftMouseButtonDragY?.Invoke(value.y);
        }

        private void OnRMBDrag(Vector2 value)
        {
            onRightMouseButtonDragX?.Invoke(value.x);
            onRightMouseButtonDragY?.Invoke(value.y);
        }

        private void OnMMBDrag(Vector2 value)
        {
            onMiddleMouseButtonDragX?.Invoke(value.x);
            onMiddleMouseButtonDragY?.Invoke(value.y);
        }
    }
}