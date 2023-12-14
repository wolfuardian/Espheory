using UnityEngine;
using Eos.Runtime.Core;
using Eos.Runtime.Events.ScriptableObjects;

namespace Eos.Runtime
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

        public bool IsUpdateHandlerIsNull() => PersistentManager.instance == null;

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
            PersistentManager.instance.Register(this);
        }

        private void OnDestroy()
        {
            if (mouseEventChannel == null) return;

            if (IsUpdateHandlerIsNull()) return;
            PersistentManager.instance.Unregister(this);
        }

        private void OnEnable()
        {
            mouseEventChannel.onMousePosition += OnMouseMoving;
        }

        private void OnDisable()
        {
            mouseEventChannel.onMousePosition -= OnMouseMoving;
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