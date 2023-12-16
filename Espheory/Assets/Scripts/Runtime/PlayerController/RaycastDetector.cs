using Eos.Runtime.Core;
using Eos.Runtime.Events.ScriptableObjects;
using UnityEngine;

namespace Eos.Runtime.PlayerController
{
    public class RaycastDetector : ModuleBase
    {
        public bool isUpdateHandlerIsNull => PersistentManager.instance == null;

        [Header("Listening to")] [SerializeField]
        private MouseEventChannelSO mouseEvent;

        [SerializeField] private CameraEventChannelSO cameraEvent;

        [Header("Broadcasting on")] [SerializeField]
        private RaycastEventChannelSO raycastEvent;

        public GameObject raycastHitGameObject => GetRaycastHitGameObjectByCamera(_mainCamera);
        public bool isRayCastHitOnCollider => raycastHitGameObject != null;
        private Vector3 _mousePosition;
        private Camera _mainCamera;

        private void Start()
        {
            if (mouseEvent == null)
            {
                Debug.Log("Mouse Event Channel is null", this);
                return;
            }

            if (isUpdateHandlerIsNull) return;
            PersistentManager.instance.Register(this);
        }

        private void OnDestroy()
        {
            if (mouseEvent == null) return;

            if (isUpdateHandlerIsNull) return;
            PersistentManager.instance.Unregister(this);
        }

        private void OnEnable()
        {
            mouseEvent.onMousePosition += OnMousePosition;
            cameraEvent.onCameraPossessed += OnCameraPossessed;
        }

        private void OnCameraPossessed(Camera value)
        {
            _mainCamera = value;
        }


        private void OnDisable()
        {
            mouseEvent.onMousePosition -= OnMousePosition;
            cameraEvent.onCameraPossessed -= OnCameraPossessed;
        }

        public override void Tick()
        {
            if (mouseEvent == null) return;

            if (isRayCastHitOnCollider)
            {
                raycastEvent.RaiseRaycastHitEvent();
                raycastEvent.RaiseRaycastHitGameObjectEvent(raycastHitGameObject);
            }
        }

        private void OnMousePosition(Vector2 value) => _mousePosition = value;

        private GameObject GetRaycastHitGameObjectByCamera(Camera cam) =>
            Physics.Raycast(cam.ScreenPointToRay(_mousePosition), out var hit)
                ? hit.collider.gameObject
                : null;
    }
}