using UnityEngine;
using UnityEngine.Events;
using Eos.Events.ScriptableObjects;

namespace Eos.Runtime.Mouse
{
    public class MouseEventListener : MonoBehaviour
    {
        [Header("Listening to")] [SerializeField]
        private MouseEventChannelSO onMouseEventChannel;

        [Header("UnityEvent Response")] [SerializeField]
        private UnityEvent<bool> onLMBPressEventRaised;

        [SerializeField] private UnityEvent<bool> onMMBPressEventRaised;
        [SerializeField] private UnityEvent<bool> onRMBPressEventRaised;
        [SerializeField] private UnityEvent onLMBHoldEventRaised;
        [SerializeField] private UnityEvent onMMBHoldEventRaised;
        [SerializeField] private UnityEvent onRMBHoldEventRaised;
        [SerializeField] private UnityEvent<float> onLMBHoldFramesEventRaised;
        [SerializeField] private UnityEvent<float> onMMBHoldFramesEventRaised;
        [SerializeField] private UnityEvent<float> onRMBHoldFramesEventRaised;
        [SerializeField] private UnityEvent<float> onMousePositionXEventRaised;
        [SerializeField] private UnityEvent<float> onMousePositionYEventRaised;
        [SerializeField] private UnityEvent<float> onMouseMoveDeltaXEventRaised;
        [SerializeField] private UnityEvent<float> onMouseMoveDeltaYEventRaised;
        [SerializeField] private UnityEvent<float> onMouseScrollDeltaEventRaised;
        [SerializeField] private UnityEvent<string> onMousePositionXStringEventRaised;
        [SerializeField] private UnityEvent<string> onMousePositionYStringEventRaised;
        [SerializeField] private UnityEvent<string> onMouseMoveDeltaXStringEventRaised;
        [SerializeField] private UnityEvent<string> onMouseMoveDeltaYStringEventRaised;
        [SerializeField] private UnityEvent<string> onMouseScrollDeltaStringEventRaised;


        private void OnEnable()
        {
            onMouseEventChannel.OnLMBPressEventRaised += OnLeftMouseButtonPressed;
            onMouseEventChannel.OnLMBReleaseEventRaised += OnLeftMouseButtonReleased;
            onMouseEventChannel.OnLMBHoldEventRaised += OnLeftMouseButtonHold;
            onMouseEventChannel.OnMMBPressEventRaised += OnMiddleMouseButtonPressed;
            onMouseEventChannel.OnMMBReleaseEventRaised += OnMiddleMouseButtonReleased;
            onMouseEventChannel.OnMMBHoldEventRaised += OnMiddleMouseButtonHold;
            onMouseEventChannel.OnRMBPressEventRaised += OnRightMouseButtonPressed;
            onMouseEventChannel.OnRMBReleaseEventRaised += OnRightMouseButtonReleased;
            onMouseEventChannel.OnRMBHoldEventRaised += OnRightMouseButtonHold;
            onMouseEventChannel.OnLMBHoldFramesEventRaised += OnLMBHoldFramesEventRaised;
            onMouseEventChannel.OnMMBHoldFramesEventRaised += OnMMBHoldFramesEventRaised;
            onMouseEventChannel.OnRMBHoldFramesEventRaised += OnRMBHoldFramesEventRaised;
            onMouseEventChannel.OnMousePositionEventRaised += OnMousePositionEventRaised;
            onMouseEventChannel.OnMouseMoveDeltaEventRaised += OnMouseMoveDeltaEventRaised;
            onMouseEventChannel.OnMouseScrollDeltaEventRaised += OnMouseScrollDeltaEventRaised;
        }

        private void OnDisable()
        {
            onMouseEventChannel.OnLMBPressEventRaised -= OnLeftMouseButtonPressed;
            onMouseEventChannel.OnLMBReleaseEventRaised -= OnLeftMouseButtonReleased;
            onMouseEventChannel.OnLMBHoldEventRaised -= OnLeftMouseButtonHold;
            onMouseEventChannel.OnMMBPressEventRaised -= OnMiddleMouseButtonPressed;
            onMouseEventChannel.OnMMBReleaseEventRaised -= OnMiddleMouseButtonReleased;
            onMouseEventChannel.OnMMBHoldEventRaised -= OnMiddleMouseButtonHold;
            onMouseEventChannel.OnRMBPressEventRaised -= OnRightMouseButtonPressed;
            onMouseEventChannel.OnRMBReleaseEventRaised -= OnRightMouseButtonReleased;
            onMouseEventChannel.OnRMBHoldEventRaised -= OnRightMouseButtonHold;
            onMouseEventChannel.OnLMBHoldFramesEventRaised -= OnLMBHoldFramesEventRaised;
            onMouseEventChannel.OnMMBHoldFramesEventRaised -= OnMMBHoldFramesEventRaised;
            onMouseEventChannel.OnRMBHoldFramesEventRaised -= OnRMBHoldFramesEventRaised;
            onMouseEventChannel.OnMousePositionEventRaised -= OnMousePositionEventRaised;
            onMouseEventChannel.OnMouseMoveDeltaEventRaised -= OnMouseMoveDeltaEventRaised;
            onMouseEventChannel.OnMouseScrollDeltaEventRaised -= OnMouseScrollDeltaEventRaised;
        }

        private void OnLeftMouseButtonPressed()
        {
            onLMBPressEventRaised?.Invoke(true);
        }

        private void OnLeftMouseButtonReleased()
        {
            onLMBPressEventRaised?.Invoke(false);
            onLMBHoldFramesEventRaised?.Invoke(0);
        }

        private void OnLeftMouseButtonHold()
        {
            onLMBHoldEventRaised?.Invoke();
        }

        private void OnMiddleMouseButtonPressed()
        {
            onMMBPressEventRaised?.Invoke(true);
        }

        private void OnMiddleMouseButtonReleased()
        {
            onMMBPressEventRaised?.Invoke(false);
            onMMBHoldFramesEventRaised?.Invoke(0);
        }

        private void OnMiddleMouseButtonHold()
        {
            onMMBHoldEventRaised?.Invoke();
        }

        private void OnRightMouseButtonPressed()
        {
            onRMBPressEventRaised?.Invoke(true);
        }

        private void OnRightMouseButtonReleased()
        {
            onRMBPressEventRaised?.Invoke(false);
            onRMBHoldFramesEventRaised?.Invoke(0);
        }

        private void OnRightMouseButtonHold()
        {
            onRMBHoldEventRaised?.Invoke();
        }

        private void OnLMBHoldFramesEventRaised(int value)
        {
            onLMBHoldFramesEventRaised?.Invoke(value);
        }

        private void OnMMBHoldFramesEventRaised(int value)
        {
            onMMBHoldFramesEventRaised?.Invoke(value);
        }

        private void OnRMBHoldFramesEventRaised(int value)
        {
            onRMBHoldFramesEventRaised?.Invoke(value);
        }

        private void OnMousePositionEventRaised(Vector2Int value)
        {
            onMousePositionXEventRaised?.Invoke(value.x);
            onMousePositionYEventRaised?.Invoke(value.y);
            onMousePositionXStringEventRaised?.Invoke(value.x.ToString());
            onMousePositionYStringEventRaised?.Invoke(value.y.ToString());
        }

        private void OnMouseMoveDeltaEventRaised(Vector2Int value)
        {
            onMouseMoveDeltaXEventRaised?.Invoke(value.x);
            onMouseMoveDeltaYEventRaised?.Invoke(value.y);
            onMouseMoveDeltaXStringEventRaised?.Invoke(value.x.ToString());
            onMouseMoveDeltaYStringEventRaised?.Invoke(value.y.ToString());
        }

        private void OnMouseScrollDeltaEventRaised(int value)
        {
            onMouseScrollDeltaEventRaised?.Invoke(value);
            onMouseScrollDeltaStringEventRaised?.Invoke(value.ToString());
        }
    }
}