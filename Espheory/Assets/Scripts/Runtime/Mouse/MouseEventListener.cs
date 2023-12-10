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

        [SerializeField] private UnityEvent<bool> onRMBPressEventRaised;
        [SerializeField] private UnityEvent<bool> onMMBPressEventRaised;
        [SerializeField] private UnityEvent onLMBHoldEventRaised;
        [SerializeField] private UnityEvent onRMBHoldEventRaised;
        [SerializeField] private UnityEvent onMMBHoldEventRaised;
        [SerializeField] private UnityEvent<float> onLMBHoldFramesEventRaised;
        [SerializeField] private UnityEvent<float> onRMBHoldFramesEventRaised;
        [SerializeField] private UnityEvent<float> onMMBHoldFramesEventRaised;
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
        [SerializeField] private UnityEvent<float> onLMBDragXEventRaised;
        [SerializeField] private UnityEvent<float> onLMBDragYEventRaised;
        [SerializeField] private UnityEvent<float> onRMBDragXEventRaised;
        [SerializeField] private UnityEvent<float> onRMBDragYEventRaised;
        [SerializeField] private UnityEvent<float> onMMBDragXEventRaised;
        [SerializeField] private UnityEvent<float> onMMBDragYEventRaised;
        [SerializeField] private UnityEvent<string> onLMBDragXStringEventRaised;
        [SerializeField] private UnityEvent<string> onLMBDragYStringEventRaised;
        [SerializeField] private UnityEvent<string> onRMBDragXStringEventRaised;
        [SerializeField] private UnityEvent<string> onRMBDragYStringEventRaised;
        [SerializeField] private UnityEvent<string> onMMBDragXStringEventRaised;
        [SerializeField] private UnityEvent<string> onMMBDragYStringEventRaised;

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
            onMouseEventChannel.OnLMBDragEventRaised += OnLMBDragEventRaised;
            onMouseEventChannel.OnRMBDragEventRaised += OnRMBDragEventRaised;
            onMouseEventChannel.OnMMBDragEventRaised += OnMMBDragEventRaised;
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
            onMouseEventChannel.OnLMBDragEventRaised -= OnLMBDragEventRaised;
            onMouseEventChannel.OnRMBDragEventRaised -= OnRMBDragEventRaised;
            onMouseEventChannel.OnMMBDragEventRaised -= OnMMBDragEventRaised;
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

        private void OnLMBHoldFramesEventRaised(int value)
        {
            onLMBHoldFramesEventRaised?.Invoke(value);
        }

        private void OnRMBHoldFramesEventRaised(int value)
        {
            onRMBHoldFramesEventRaised?.Invoke(value);
        }

        private void OnMMBHoldFramesEventRaised(int value)
        {
            onMMBHoldFramesEventRaised?.Invoke(value);
        }

        private void OnMousePositionEventRaised(Vector2 value)
        {
            onMousePositionXEventRaised?.Invoke(value.x);
            onMousePositionYEventRaised?.Invoke(value.y);
            onMousePositionXStringEventRaised?.Invoke(value.x.ToString("F2"));
            onMousePositionYStringEventRaised?.Invoke(value.y.ToString("F2"));
        }

        private void OnMouseMoveDeltaEventRaised(Vector2 value)
        {
            onMouseMoveDeltaXEventRaised?.Invoke(value.x);
            onMouseMoveDeltaYEventRaised?.Invoke(value.y);
            onMouseMoveDeltaXStringEventRaised?.Invoke(value.x.ToString("F2"));
            onMouseMoveDeltaYStringEventRaised?.Invoke(value.y.ToString("F2"));
        }

        private void OnMouseScrollDeltaEventRaised(float value)
        {
            onMouseScrollDeltaEventRaised?.Invoke(value);
            onMouseScrollDeltaStringEventRaised?.Invoke(value.ToString("F2"));
        }
        
        private void OnLMBDragEventRaised(Vector2 value)
        {
            onLMBDragXEventRaised?.Invoke(value.x);
            onLMBDragYEventRaised?.Invoke(value.y);
            onLMBDragXStringEventRaised?.Invoke(value.x.ToString("F2"));
            onLMBDragYStringEventRaised?.Invoke(value.y.ToString("F2"));
        }

        private void OnRMBDragEventRaised(Vector2 value)
        {
            onRMBDragXEventRaised?.Invoke(value.x);
            onRMBDragYEventRaised?.Invoke(value.y);
            onRMBDragXStringEventRaised?.Invoke(value.x.ToString("F2"));
            onRMBDragYStringEventRaised?.Invoke(value.y.ToString("F2"));
        }

        private void OnMMBDragEventRaised(Vector2 value)
        {
            onMMBDragXEventRaised?.Invoke(value.x);
            onMMBDragYEventRaised?.Invoke(value.y);
            onMMBDragXStringEventRaised?.Invoke(value.x.ToString("F2"));
            onMMBDragYStringEventRaised?.Invoke(value.y.ToString("F2"));
        }
    }
}