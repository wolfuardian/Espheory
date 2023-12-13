using UnityEngine;

namespace Eos.Utils.Math
{
    public static class MathUtils
    {
        public static float FInterp(float current, float target, float deltaTime, float interpSpeed)
        {
            return current + (target - current) * deltaTime * interpSpeed;
        }

        public static Vector3 VInterp(Vector3 current, Vector3 target, float deltaTime, float interpSpeed)
        {
            return current + (target - current) * deltaTime * interpSpeed;
        }
    }
}