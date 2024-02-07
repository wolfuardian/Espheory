using UnityEngine;

namespace Eos.Utils.System
{
    public static class TransformExtensions
    {
        public static void SetYRotation(this Transform transform, float yRotation)
        {
            var eulerAngles = transform.eulerAngles;
            eulerAngles.y         = yRotation;
            transform.eulerAngles = eulerAngles;
        }

        public static void MovePosition(this Transform transform, Vector3 direction, float moveSpeed)
        {
            transform.position += direction * moveSpeed;
        }

        public static void SetYPosition(this Transform transform, float yPos)
        {
            var position = transform.position;
            position.y         = yPos;
            transform.position = position;
        }

        public static Vector3 ForwardDirection(this Transform transform, float scale)
        {
            return transform.forward * scale;
        }

        public static Vector3 RightDirection(this Transform transform, float scale)
        {
            return transform.right * scale;
        }

        public static void AdjustYaw(this Transform transform, float yawDelta, float scaleFactor = 0.1f)
        {
            var eulerAngles = transform.eulerAngles;
            eulerAngles.y         += yawDelta * scaleFactor;
            transform.eulerAngles =  eulerAngles;
        }
    }
}