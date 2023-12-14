using UnityEngine;
using Eos.Utils.Math;
using Eos.Events.ScriptableObjects;
using Eos.Runtime.Core;
using Eos.Runtime.Interface;

namespace Eos.Runtime.Player
{
    public class CameraProxy : MonoBehaviour, ITick
    {
        [Header("Listening to")] [SerializeField]
        private MouseEventChannelSO mouseEventChannel;

        [Header("Binding")] [SerializeField] private Transform cameraPivot;
        [SerializeField] private Transform cameraPitchYaw;
        [SerializeField] private Transform cameraDolly;
        [SerializeField] private Camera mainCamera;

        [Header("Config")] [SerializeField] private CameraConfigDataSO cameraConfigData;

        private Vector3 _targetCameraPivot;
        private Vector3 _targetCameraPitchYaw;
        private Vector3 _targetCameraDolly;
        private Vector3 _currentCameraPivot;
        private Vector3 _currentCameraPitchYaw;
        private Vector3 _currentCameraDolly;
        private Vector2 _mouseMoveDelta;
        private bool _isMiddleMouseButtonDragging;

        public bool IsUpdateHandlerIsNull() => GlobalUpdater.instance == null;

        private void Awake()
        {
            _targetCameraPivot = cameraPivot.localPosition;
            _targetCameraPitchYaw = cameraPitchYaw.localEulerAngles;
            _targetCameraDolly = cameraDolly.localPosition;

            _currentCameraPivot = _targetCameraPivot;
            _currentCameraPitchYaw = _targetCameraPitchYaw;
            _currentCameraDolly = _targetCameraDolly;
        }

        private void Start()
        {
            if (IsUpdateHandlerIsNull()) return;
            GlobalUpdater.instance.Register(this);
        }

        private void OnDestroy()
        {
            if (IsUpdateHandlerIsNull()) return;
            GlobalUpdater.instance.Unregister(this);
        }

        private void OnEnable()
        {
            mouseEventChannel.onMouseMoveDelta += OnMouseMoveDelta;
            mouseEventChannel.onMouseScrollDelta += OnMouseScrollDelta;
            mouseEventChannel.onMiddleMouseButtonDrag += OnMiddleMouseButtonDrag;
        }

        private void OnDisable()
        {
            mouseEventChannel.onMouseMoveDelta -= OnMouseMoveDelta;
            mouseEventChannel.onMouseScrollDelta -= OnMouseScrollDelta;
            mouseEventChannel.onMiddleMouseButtonDrag -= OnMiddleMouseButtonDrag;
        }

        private void OnMouseMoveDelta(Vector2 value) => _mouseMoveDelta = value;

        private void OnMouseScrollDelta(float value)
        {
            _targetCameraDolly.z += value * cameraConfigData.scrollStrength * 1f;
        }

        private void OnMiddleMouseButtonDrag()
        {
            _targetCameraPitchYaw.x += _mouseMoveDelta.y * cameraConfigData.pitchStrength * -1f;
            _targetCameraPitchYaw.y += _mouseMoveDelta.x * cameraConfigData.yawStrength;
        }

        public void Tick()
        {
            UpdatePivot(_currentCameraPivot, _targetCameraPivot, Time.deltaTime, cameraConfigData.interpSpeed);
            UpdatePitchYaw(_currentCameraPitchYaw, _targetCameraPitchYaw, Time.deltaTime, cameraConfigData.interpSpeed);
            UpdateDolly(_currentCameraDolly, _targetCameraDolly, Time.deltaTime, cameraConfigData.interpSpeed);

            ApplyPivot();
            ApplyPitchYaw();
            ApplyDolly();
        }

        private void UpdatePivot(Vector3 current, Vector3 target, float deltaTime, float interpSpeed)
        {
            _currentCameraPivot = MathUtils.VInterp(current, target, deltaTime, interpSpeed);
        }

        private void UpdatePitchYaw(Vector3 current, Vector3 target, float deltaTime, float interpSpeed)
        {
            _currentCameraPitchYaw = MathUtils.VInterp(current, target, deltaTime, interpSpeed);
        }

        private void UpdateDolly(Vector3 current, Vector3 target, float deltaTime, float interpSpeed)
        {
            _currentCameraDolly = MathUtils.VInterp(current, target, deltaTime, interpSpeed);
        }

        private void ApplyPivot()
        {
            cameraPivot.localPosition = _currentCameraPivot;
        }

        private void ApplyPitchYaw()
        {
            cameraPitchYaw.localEulerAngles = _currentCameraPitchYaw;
        }

        private void ApplyDolly()
        {
            cameraDolly.localPosition = _currentCameraDolly;
        }
    }
}