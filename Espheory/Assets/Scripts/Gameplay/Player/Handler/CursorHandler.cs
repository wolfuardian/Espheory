#region

using Eos.Gameplay.Context.Scene;
using Eos.Gameplay.Player.Main;
using UnityEngine;
using Zenject;

#endregion

namespace Eos.Gameplay.Player.Handler
{
    public class CursorHandler : ITickable
    {
        #region Public Variables

        [Inject]                      private readonly InputState _inputState;
        [Inject]                      private readonly ACursor    _cursorActor;
        [Inject]                      private readonly ACamera    _cameraActor;
        [Inject(Id = "LAYER_GROUND")] private readonly string     _groundLayerName;

        #endregion

        #region Public Methods

        public void Tick()
        {
            if (!_inputState.Select) return;
            if (_inputState.LookAround) return;
            var raycastHitPosition = RaycastPosition(_inputState.PointerPosition);
            if (raycastHitPosition == Vector3.zero) return;
            _cursorActor.SetPosition(raycastHitPosition);
        }

        public Vector3 RaycastPosition(Vector2 screenPosition)
        {
            var ray       = _cameraActor.GetCamera().ScreenPointToRay(screenPosition);
            var layerMask = LayerMask.GetMask(_groundLayerName);
            return Physics.Raycast(ray, out var hit, Mathf.Infinity, layerMask) ? hit.point : Vector3.zero;
        }

        #endregion
    }
}