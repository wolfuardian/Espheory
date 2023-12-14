using UnityEngine;

namespace Eos.Runtime.Modules.Player
{
    [CreateAssetMenu(menuName = "Data/Camera Config Data")]
    public class CameraConfigDataSO : ScriptableObject
    {
        public float scrollStrength = 1f;
        public float pitchStrength = 1f;
        public float yawStrength = 1f;
        public float interpSpeed = 10f;
    }
}