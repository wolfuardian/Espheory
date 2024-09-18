#region

using Gameplay.CameraRaycast.Scripts.Core;
using Gameplay.Input.Core;
using UnityEngine;
using Zenject;

#endregion

namespace Gameplay.CameraRaycast.Scripts.Mono
{
    public class CameraRaycastDebugger : MonoBehaviour
    {
        #region Private Valiables

        [Inject] private IInputState      inputState;
        [Inject] private IViewportService viewport;

        [SerializeField] private float m_SphereRadius = 0.2f;

        #endregion

        #region Private Methods

        private void OnGUI()
        {
            GUILayout.Label($"PointerPosition: {inputState.PointerPosition}");
            GUILayout.Label($"Cursor Position: {viewport.GetCursor3D().Position}");
            GUILayout.Label($"Camera Position: {viewport.GetCamera().Position}");
        }

        private void OnDrawGizmos()
        {
            if (viewport != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(viewport.GetCursor3D().Position, m_SphereRadius);
                Gizmos.DrawLine(viewport.GetCamera().Position, viewport.GetCursor3D().Position);
            }
        }

        #endregion
    }
}
