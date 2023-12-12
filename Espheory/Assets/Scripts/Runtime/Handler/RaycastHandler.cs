using Eos.Runtime.Core;
using Eos.Runtime.Interface;
using Eos.Events.ScriptableObjects;
using UnityEngine;

namespace Eos.Runtime.Handler
{
    public class RaycastHandler : MonoBehaviour, ITick
    {
        [Header("Listening to")] [SerializeField]
        private MouseEventChannelSO mouseEventChannel;

        [Header("Broadcasting on")] [SerializeField]
        private BoolEventChannelSO raycastHitEventChannel;

        [SerializeField] private CameraRaycastEventChannelSO cameraRaycastEventChannel;

        private Camera _camera;
        private Vector3 _mousePosition;
        [Header("Debug")] [SerializeField] private bool isRaycastHit;
        [SerializeField] private GameObject raycastHitGameObject;

        public bool IsUpdateHandlerIsNull() => UpdateHandler.instance == null;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            if (mouseEventChannel == null)
            {
                Debug.Log("Mouse Event Channel is null", this);
                return;
            }

            if (IsUpdateHandlerIsNull()) return;
            UpdateHandler.instance.Register(this);
        }

        private void OnDestroy()
        {
            if (mouseEventChannel == null) return;

            if (IsUpdateHandlerIsNull()) return;
            UpdateHandler.instance.Unregister(this);
        }

        private void OnEnable()
        {
            mouseEventChannel.OnMousePosition += OnMouseMoving;
        }

        private void OnDisable()
        {
            mouseEventChannel.OnMousePosition -= OnMouseMoving;
        }

        private void OnMouseMoving(Vector2 position)
        {
            _mousePosition = position;
        }

        public void Tick()
        {
            RaycastHitByCamera();
            raycastHitEventChannel.RaiseEvent(isRaycastHit);
            cameraRaycastEventChannel.RaiseEvent(raycastHitGameObject);
        }

        private void RaycastHitByCamera()
        {
            var ray = _camera.ScreenPointToRay(_mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                isRaycastHit = true;
                raycastHitGameObject = hit.collider.gameObject;
            }
            else
            {
                raycastHitGameObject = null;
                isRaycastHit = false;
            }
        }
    }
}