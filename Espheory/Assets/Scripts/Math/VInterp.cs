using UnityEngine;

namespace Math
{
    public static class VInterp
    {
        public static Vector3 Linear(Vector3 start, Vector3 end, float t)
        {
            return start + (end - start) * t;
        }

        public static Vector3 EaseInOutQuad(Vector3 start, Vector3 end, float t)
        {
            t = Mathf.Clamp01(t);
            return start + (end - start) * (t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t);
        }
    }
}