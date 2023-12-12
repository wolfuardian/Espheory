using UnityEngine;
using UnityEngine.Events;

namespace Eos.Events.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Events/Mouse Event Channel")]
    public class MouseEventChannelSO : ScriptableObject
    {
        public UnityAction OnLeftMouseButtonPress;
        public UnityAction OnLeftMouseButtonRelease;
        public UnityAction OnLeftMouseButtonHold;
        public UnityAction OnRightMouseButtonPress;
        public UnityAction OnRightMouseButtonRelease;
        public UnityAction OnRightMouseButtonHold;
        public UnityAction OnMiddleMouseButtonPress;
        public UnityAction OnMiddleMouseButtonRelease;
        public UnityAction OnMiddleMouseButtonHold;
        public UnityAction OnScroll;
        public UnityAction<int> OnLeftMouseButtonHoldFrames;
        public UnityAction<int> OnRightMouseButtonHoldFrames;
        public UnityAction<int> OnMiddleMouseButtonHoldFrames;
        public UnityAction<Vector2> OnMousePosition;
        public UnityAction<Vector2> OnMouseMoveDelta;
        public UnityAction<float> OnMouseScrollDelta;
        public UnityAction<Vector2> OnLeftMouseButtonDrag;
        public UnityAction<Vector2> OnRightMouseButtonDrag;
        public UnityAction<Vector2> OnMiddleMouseButtonDrag;

        public void RaiseLeftMouseButtonPressEvent() => OnLeftMouseButtonPress?.Invoke();
        public void RaiseLeftMouseButtonReleaseEvent() => OnLeftMouseButtonRelease?.Invoke();
        public void RaiseLeftMouseButtonHoldEvent() => OnLeftMouseButtonHold?.Invoke();
        public void RaiseRightMouseButtonPressEvent() => OnRightMouseButtonPress?.Invoke();
        public void RaiseRightMouseButtonReleaseEvent() => OnRightMouseButtonRelease?.Invoke();
        public void RaiseRightMouseButtonHoldEvent() => OnRightMouseButtonHold?.Invoke();
        public void RaiseMiddleMouseButtonPressEvent() => OnMiddleMouseButtonPress?.Invoke();
        public void RaiseMiddleMouseButtonReleaseEvent() => OnMiddleMouseButtonRelease?.Invoke();
        public void RaiseMiddleMouseButtonHoldEvent() => OnMiddleMouseButtonHold?.Invoke();
        public void RaiseLeftMouseButtonHoldFramesEvent(int value) => OnLeftMouseButtonHoldFrames?.Invoke(value);
        public void RaiseRightMouseButtonHoldFramesEvent(int value) => OnRightMouseButtonHoldFrames?.Invoke(value);
        public void RaiseMiddleMouseButtonHoldFramesEvent(int value) => OnMiddleMouseButtonHoldFrames?.Invoke(value);
        public void RaiseScrollEvent() => OnScroll?.Invoke();
        public void RaiseMousePositionEvent(Vector2 value) => OnMousePosition?.Invoke(value);
        public void RaiseMouseMoveDeltaEvent(Vector2 value) => OnMouseMoveDelta?.Invoke(value);
        public void RaiseMouseScrollDeltaEvent(float value) => OnMouseScrollDelta?.Invoke(value);
        public void RaiseLeftMouseButtonDragEvent(Vector2 value) => OnLeftMouseButtonDrag?.Invoke(value);
        public void RaiseRightMouseButtonDragEvent(Vector2 value) => OnRightMouseButtonDrag?.Invoke(value);
        public void RaiseMiddleMouseButtonDragEvent(Vector2 value) => OnMiddleMouseButtonDrag?.Invoke(value);
    }
}