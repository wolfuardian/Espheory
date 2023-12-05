using UnityEngine;

namespace Eos.Scripts.Utils.Math
{
    public static class FInterp
    {
        public static float Linear(float start, float end, float t)
        {
            return start + (end - start) * t;
        }

        public static float EaseInOutQuad(float start, float end, float t)
        {
            t = Mathf.Clamp01(t);
            return start + (end - start) * (t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t);
        }
    }
}