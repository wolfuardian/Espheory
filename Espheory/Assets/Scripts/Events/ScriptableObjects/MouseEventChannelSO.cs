using UnityEngine;
using UnityEngine.Events;

namespace Eos.Events.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Events/Mouse Event Channel")]
    public class MouseEventChannelSO : ScriptableObject
    {
        public UnityAction OnLMBPressEventRaised;
        public UnityAction OnLMBReleaseEventRaised;
        public UnityAction OnLMBHoldEventRaised;
        public UnityAction OnMMBPressEventRaised;
        public UnityAction OnMMBReleaseEventRaised;
        public UnityAction OnMMBHoldEventRaised;
        public UnityAction OnRMBPressEventRaised;
        public UnityAction OnRMBReleaseEventRaised;
        public UnityAction OnRMBHoldEventRaised;
        public UnityAction<int> OnLMBHoldFramesEventRaised;
        public UnityAction<int> OnMMBHoldFramesEventRaised;
        public UnityAction<int> OnRMBHoldFramesEventRaised;
        public UnityAction<Vector2> OnMousePositionEventRaised;
        public UnityAction<Vector2> OnMouseMoveDeltaEventRaised;
        public UnityAction<float> OnMouseScrollDeltaEventRaised;
        public UnityAction<Vector2> OnLMBDragEventRaised;
        public UnityAction<Vector2> OnMMBDragEventRaised;
        public UnityAction<Vector2> OnRMBDragEventRaised;

        public void RaiseLMBPressEvent() => OnLMBPressEventRaised?.Invoke();
        public void RaiseLMBReleaseEvent() => OnLMBReleaseEventRaised?.Invoke();
        public void RaiseLMBHoldEvent() => OnLMBHoldEventRaised?.Invoke();
        public void RaiseMMBPressEvent() => OnMMBPressEventRaised?.Invoke();
        public void RaiseMMBReleaseEvent() => OnMMBReleaseEventRaised?.Invoke();
        public void RaiseMMBHoldEvent() => OnMMBHoldEventRaised?.Invoke();
        public void RaiseRMBPressEvent() => OnRMBPressEventRaised?.Invoke();
        public void RaiseRMBReleaseEvent() => OnRMBReleaseEventRaised?.Invoke();
        public void RaiseRMBHoldEvent() => OnRMBHoldEventRaised?.Invoke();
        public void RaiseLMBHoldFramesEvent(int value) => OnLMBHoldFramesEventRaised?.Invoke(value);
        public void RaiseMMBHoldFramesEvent(int value) => OnMMBHoldFramesEventRaised?.Invoke(value);
        public void RaiseRMBHoldFramesEvent(int value) => OnRMBHoldFramesEventRaised?.Invoke(value);
        public void RaiseMousePositionEvent(Vector2 value) => OnMousePositionEventRaised?.Invoke(value);
        public void RaiseMouseMoveDeltaEvent(Vector2 value) => OnMouseMoveDeltaEventRaised?.Invoke(value);
        public void RaiseMouseScrollDeltaEvent(float value) => OnMouseScrollDeltaEventRaised?.Invoke(value);
        public void RaiseLMBDragEvent(Vector2 value) => OnLMBDragEventRaised?.Invoke(value);
        public void RaiseMMBDragEvent(Vector2 value) => OnMMBDragEventRaised?.Invoke(value);
        public void RaiseRMBDragEvent(Vector2 value) => OnRMBDragEventRaised?.Invoke(value);
    }
}