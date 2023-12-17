using System;
using Eos.Runtime.Core;
using Eos.Runtime.Events.ScriptableObjects.PlayerController;
using UnityEngine;

namespace Eos.Runtime.PlayerController
{
    public class CursorLocator : ModuleBase
    {
        [Header("Listening to")] [SerializeField]
        private RaycastEventChannelSO raycastEvent;

        [SerializeField] private MouseEventChannelSO mouseEvent;

        [Header("Config")] [SerializeField] private CursorConfigDataSO cursorConfigData;

        private Vector3 _cursorPosition;
        private GameObject _cursor;
        private RaycastHit _raycastHit;
        private void OnRaycastHit(RaycastHit value) => _raycastHit = value;
        private bool isRayCastHitOnCollider => _raycastHit.collider != null;

        private void Awake()
        {
            _cursor = Instantiate(cursorConfigData.cursorPrefab);
        }

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
            raycastEvent.onRaycastHit += OnRaycastHit;
            mouseEvent.onLeftMouseButtonHold += LocateCursor;
        }

        private void OnDisable()
        {
            raycastEvent.onRaycastHit -= OnRaycastHit;
            mouseEvent.onLeftMouseButtonHold -= LocateCursor;
        }

        public override void Tick()
        {
            if (isRayCastHitOnCollider) OnRaycastHitReceived();
        }

        private void OnRaycastHitReceived() => UpdateCursorPosition();
        private void UpdateCursorPosition() => _cursorPosition = _raycastHit.point;

        private void LocateCursor()
        {
            _cursor.transform.position = _cursorPosition;
            _cursor.transform.rotation = Quaternion.FromToRotation(Vector3.up, _raycastHit.normal);
        }
    }
}