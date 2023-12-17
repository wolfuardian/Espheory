using UnityEngine;
using Eos.Editor.Attribute;

namespace Eos.Runtime.PlayerController
{
    [CreateAssetMenu(menuName = "Data/Cursor Config Data")]
    public class CursorConfigDataSO : ScriptableObject
    {
        [Prefab]
        public GameObject cursorPrefab;
    }
}