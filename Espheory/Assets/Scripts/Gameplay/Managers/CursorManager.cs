using UnityEngine;
using Eos.Gameplay.Input;
using Eos.Gameplay.RuntimeAnchors;

namespace Eos.Gameplay.Managers
{
    public class CursorManager : MonoBehaviour
    {
        [SerializeField] private Transform       cursor;
        [SerializeField] private TransformAnchor cursorAnchor;

        private void OnEnable()
        {
            cursorAnchor.Provide(cursor.transform);
        }

        private void OnDisable()
        {
            cursorAnchor.Unset();
        }

        public void MoveCursor(Vector3 transformPosition)
        {
            cursor.position = transformPosition;
        }
    }
}