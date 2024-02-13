using UnityEngine;
using Eos.Gameplay.Input;
using Eos.Core.Attribute.ReadOnlyAttribute;

namespace Eos.Gameplay.Managers
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private InputReader   _inputReader;
        [SerializeField] private Camera        _mainCamera;
        [SerializeField] private CursorManager _cursorManager;

        [ReadOnly] [SerializeField] private GameObject _identifyObject;
        [ReadOnly] [SerializeField] private bool       _isSelecting;

        private void Awake()
        {
            if (_inputReader == null)
                Debug.LogError("未在 CameraManager 中設定 InputReader", this);
        }

        private void OnEnable()
        {
            if (_inputReader == null) return;
            _inputReader.SelectEvent  += OnSelect;
            _inputReader.PointerEvent += OnPointer;
        }

        private void OnDisable()
        {
            if (_inputReader == null) return;
            _inputReader.SelectEvent  -= OnSelect;
            _inputReader.PointerEvent -= OnPointer;
        }

        private void OnSelect(bool selectValue)
        {
            // 設定選擇狀態
            _isSelecting = selectValue;

            if (!_isSelecting)
                return;

            var hitInfo = RaycastPosition(_inputReader.Pointer);

            if (!hitInfo._isHit)
                return;

            // 設定游標位置
            _cursorManager.MoveCursor(hitInfo._position);
        }

        private void OnPointer(Vector2 pointerValue)
        {
            // 辨別滑鼠指向的對象
            _identifyObject = IdentifyObject(pointerValue);

            // 以下為滑鼠點擊後拖曳的操作
            // 如果不是選擇狀態，則不執行後續操作
            if (!_isSelecting || !_identifyObject)
                return;

            var hitInfo = RaycastPosition(_inputReader.Pointer);

            if (!hitInfo._isHit)
                return;

            // 設定游標位置
            _cursorManager.MoveCursor(hitInfo._position);
        }

        private GameObject IdentifyObject(Vector2 screenPosition)
        {
            var ray = _mainCamera.ScreenPointToRay(screenPosition);
            return Physics.Raycast(ray, out var hit) ? hit.transform.gameObject : null;
        }

        public struct HitInfo
        {
            public Vector3 _position;
            public bool    _isHit;
        }

        public HitInfo RaycastPosition(Vector2 screenPosition)
        {
            HitInfo h;

            var ray       = _mainCamera.ScreenPointToRay(screenPosition);
            var layerMask = LayerMask.GetMask("Ground");
            h._isHit    = Physics.Raycast(ray, out var hit, Mathf.Infinity, layerMask);
            h._position = h._isHit ? hit.point : Vector3.zero;
            return h;
        }
    }
}