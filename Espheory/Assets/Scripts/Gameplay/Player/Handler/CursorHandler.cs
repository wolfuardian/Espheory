#region

using Zenject;
using UnityEngine;
using Eos.Gameplay.Player.Main;
using Eos.Gameplay.Context.Scene;
using Eos.Gameplay.Input;

#endregion

namespace Eos.Gameplay.Player.Handler
{
    public class CursorHandler : ITickable
    {
        #region Public Variables

        [Inject]                      private readonly InputState m_InputState;
        [Inject]                      private readonly ACursor    m_CursorActor;
        [Inject]                      private readonly ACamera    m_CameraActor;
        [Inject(Id = "LAYER_GROUND")] private readonly string     m_GroundLayerName;

        #endregion

        #region Public Methods

        public void Tick()
        {
            if (!m_InputState.Select) return;
            if (m_InputState.LookAround) return;
            var raycastHitPosition = RaycastPosition(m_InputState.PointerPosition);
            if (raycastHitPosition == Vector3.zero) return;
            m_CursorActor.SetPosition(raycastHitPosition);
        }

        public Vector3 RaycastPosition(Vector2 screenPosition)
        {
            var ray       = m_CameraActor.GetCamera().ScreenPointToRay(screenPosition);
            var layerMask = LayerMask.GetMask(m_GroundLayerName);
            return Physics.Raycast(ray, out var hit, Mathf.Infinity, layerMask) ? hit.point : Vector3.zero;
        }

        #endregion
    }
}