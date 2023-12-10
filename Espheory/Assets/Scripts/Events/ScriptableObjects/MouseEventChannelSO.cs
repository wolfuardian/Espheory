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
        public UnityAction<Vector2Int> OnMousePositionEventRaised;
        public UnityAction<Vector2Int> OnMouseMoveDeltaEventRaised;
        public UnityAction<int> OnMouseScrollDeltaEventRaised;

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
        public void RaiseMousePositionEvent(Vector2Int value) => OnMousePositionEventRaised?.Invoke(value);
        public void RaiseMouseMoveDeltaEvent(Vector2Int value) => OnMouseMoveDeltaEventRaised?.Invoke(value);
        public void RaiseMouseScrollDeltaEvent(int value) => OnMouseScrollDeltaEventRaised?.Invoke(value);
    }
}