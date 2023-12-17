using Eos.Runtime.Core;
using Eos.Runtime.Events.ScriptableObjects;
using Eos.Runtime.Events.ScriptableObjects.PlayerController;
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

        public RaycastHit raycastHit => GetRaycastHitByCamera(_mainCamera);
        public bool isRayCastHitOnCollider => raycastHit.collider != null;
        private Vector3 _mousePosition;
        private Camera _mainCamera;

        private void Start()
        {
            PersistentManager.instance.Register(this);
        }

        private void OnDestroy()
        {
            PersistentManager.instance.Unregister(this);
        }

        private void OnEnable()
        {
            mouseEvent.onMousePositionChanged += OnMousePositionChanged;
            cameraEvent.onCameraPossessed += OnCameraPossessed;
        }

        private void OnCameraPossessed(Camera value)
        {
            _mainCamera = value;
        }


        private void OnDisable()
        {
            mouseEvent.onMousePositionChanged -= OnMousePositionChanged;
            cameraEvent.onCameraPossessed -= OnCameraPossessed;
        }

        public override void Tick()
        {
            if (isRayCastHitOnCollider) raycastEvent.RaiseRaycastHitEvent(raycastHit);
        }

        private void OnMousePositionChanged(Vector2 value) => _mousePosition = value;


        private RaycastHit GetRaycastHitByCamera(Camera currentCamera) =>
            Physics.Raycast(currentCamera.ScreenPointToRay(_mousePosition), out var hit)
                ? hit
                : default;
    }
}