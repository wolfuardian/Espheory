using UnityEngine;

namespace Eos.Runtime.PlayerController
{
    [CreateAssetMenu(menuName = "Data/Camera Config Data")]
    public class CameraConfigDataSO : ScriptableObject
    {
        public float scrollStrength = 1f;
        public float pitchStrength = 1f;
        public float yawStrength = 1f;
        public float interpSpeed = 10f;

        public float fieldOfView = 70f;
        public float nearClippingPlane = 0.1f;
        public float farClippingPlane = 1000f;
        public Transform followTarget;
        public Vector3 cameraOffset;
        public float rotationSensitivity = 1f;
        public float zoomSpeed = 5f;
        public PositionStabilizationSettings positionStabilization;
        public RotationStabilizationSettings rotationStabilization;
        public bool enableCollisionDetection = true;
        public Vector2 viewAngleLimits = new Vector2(-90, 90);
        public bool enableSmoothMovement = true;
        public AutoFocusSettings autoFocus;
        public ExposureSettings cameraExposure;
        public QualitySettings cameraQuality;

        [System.Serializable]
        public class PositionStabilizationSettings
        {
            public bool enablePositionStabilization = true;
        }

        [System.Serializable]
        public class RotationStabilizationSettings
        {
            public bool enableRotationStabilization = true;
        }

        [System.Serializable]
        public class AutoFocusSettings
        {
            public bool enableAutoFocus = true;
        }

        [System.Serializable]
        public class ExposureSettings
        {
            public float exposureValue = 1.0f;
        }

        [System.Serializable]
        public class QualitySettings
        {
            public int resolutionWidth = 1920;

            public int resolutionHeight = 1080;
        }
    }
}