using UnityEngine;
using UnityEngine.Events;

namespace Eos.Events.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Events/Mouse Event Channel")]
    public class MouseEventChannelSO : ScriptableObject
    {
        public UnityAction onLeftMouseButtonPress;
        public UnityAction onLeftMouseButtonRelease;
        public UnityAction onLeftMouseButtonHold;
        public UnityAction onRightMouseButtonPress;
        public UnityAction onRightMouseButtonRelease;
        public UnityAction onRightMouseButtonHold;
        public UnityAction onMiddleMouseButtonPress;
        public UnityAction onMiddleMouseButtonRelease;
        public UnityAction onMiddleMouseButtonHold;
        public UnityAction onScroll;
        public UnityAction<int> onLeftMouseButtonHoldFrames;
        public UnityAction<int> onRightMouseButtonHoldFrames;
        public UnityAction<int> onMiddleMouseButtonHoldFrames;
        public UnityAction<Vector2> onMousePosition;
        public UnityAction<Vector2> onMouseMoveDelta;
        public UnityAction<float> onMouseScrollDelta;
        public UnityAction onLeftMouseButtonDrag;
        public UnityAction onRightMouseButtonDrag;
        public UnityAction onMiddleMouseButtonDrag;
        public UnityAction<Vector2> onLeftMouseButtonDragOffset;
        public UnityAction<Vector2> onRightMouseButtonDragOffset;
        public UnityAction<Vector2> onMiddleMouseButtonDragOffset;


        public void RaiseLeftMouseButtonPressEvent() => onLeftMouseButtonPress?.Invoke();
        public void RaiseLeftMouseButtonReleaseEvent() => onLeftMouseButtonRelease?.Invoke();
        public void RaiseLeftMouseButtonHoldEvent() => onLeftMouseButtonHold?.Invoke();
        public void RaiseRightMouseButtonPressEvent() => onRightMouseButtonPress?.Invoke();
        public void RaiseRightMouseButtonReleaseEvent() => onRightMouseButtonRelease?.Invoke();
        public void RaiseRightMouseButtonHoldEvent() => onRightMouseButtonHold?.Invoke();
        public void RaiseMiddleMouseButtonPressEvent() => onMiddleMouseButtonPress?.Invoke();
        public void RaiseMiddleMouseButtonReleaseEvent() => onMiddleMouseButtonRelease?.Invoke();
        public void RaiseMiddleMouseButtonHoldEvent() => onMiddleMouseButtonHold?.Invoke();
        public void RaiseLeftMouseButtonHoldFramesEvent(int value) => onLeftMouseButtonHoldFrames?.Invoke(value);
        public void RaiseRightMouseButtonHoldFramesEvent(int value) => onRightMouseButtonHoldFrames?.Invoke(value);
        public void RaiseMiddleMouseButtonHoldFramesEvent(int value) => onMiddleMouseButtonHoldFrames?.Invoke(value);
        public void RaiseScrollEvent() => onScroll?.Invoke();
        public void RaiseMousePositionEvent(Vector2 value) => onMousePosition?.Invoke(value);
        public void RaiseMouseMoveDeltaEvent(Vector2 value) => onMouseMoveDelta?.Invoke(value);
        public void RaiseMouseScrollDeltaEvent(float value) => onMouseScrollDelta?.Invoke(value);
        public void RaiseLeftMouseButtonDrag() => onLeftMouseButtonDrag?.Invoke();
        public void RaiseRightMouseButtonDrag() => onRightMouseButtonDrag?.Invoke();
        public void RaiseMiddleMouseButtonDrag() => onMiddleMouseButtonDrag?.Invoke();
        public void RaiseLeftMouseButtonDragOffset(Vector2 value) => onLeftMouseButtonDragOffset?.Invoke(value);
        public void RaiseRightMouseButtonDragOffset(Vector2 value) => onRightMouseButtonDragOffset?.Invoke(value);
        public void RaiseMiddleMouseButtonDragOffset(Vector2 value) => onMiddleMouseButtonDragOffset?.Invoke(value);
    }
}