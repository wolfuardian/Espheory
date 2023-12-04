using UnityEngine;

namespace Eos.Scripts
{
    public class InterpolationSmoothExample : MonoBehaviour
    {
        public float startTime;
        public float duration = 2.0f;
        public Vector3 startValue = Vector3.zero;
        public Vector3 endValue = new Vector3(10.0f, 5.0f, 0.0f);

        void Start()
        {
            startTime = Time.time;
        }

        void Update()
        {
            float currentTime = Time.time - startTime;

            float t = Mathf.Clamp01(currentTime / duration);
            float easedT = EaseInOutQuad(t);

            Vector3 interpolatedValue = Lerp(startValue, endValue, easedT);

            transform.position = interpolatedValue;

            if (currentTime >= duration)
            {
                enabled = false;
            }
        }

        Vector3 Lerp(Vector3 start, Vector3 end, float t)
        {
            return start + (end - start) * t;
        }

        float EaseInOutQuad(float t)
        {
            return t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t;
        }
    }
}