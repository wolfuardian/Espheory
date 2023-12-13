using UnityEngine;

namespace Eos.Runtime.Player
{
    [CreateAssetMenu(menuName = "Data/Camera Config Data")]
    public class CameraConfigDataSO : ScriptableObject
    {
        public float scrollSpeed = 1f;
        public float pitchSpeed = 10f;
        public float yawSpeed = 10f;
        public float interpSpeed = 4f;
    }
}