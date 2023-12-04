using UnityEngine;

namespace Math
{
    public class InterpolationExample : MonoBehaviour
    {
        public float startTime;
        public float duration = 2.0f; // 插值的總時間
        public Vector3 startValue = Vector3.zero;
        public Vector3 endValue = new Vector3(10.0f, 5.0f, 0.0f); // 起始值和結束值

        void Start()
        {
            // 設定起始時間
            startTime = Time.time;
        }

        void Update()
        {
            // 計算當前時間
            float currentTime = Time.time - startTime;

            // 計算插值比例（0到1之間）
            float t = Mathf.Clamp01(currentTime / duration);

            // 使用線性插值計算中間值
            // Vector3 interpolatedValue = Lerp(startValue, endValue, t);
            var interpolatedValue = VInterp.Linear(startValue, endValue, t);


            // 應用插值結果，例如移動物體
            transform.position = interpolatedValue;

            // 當時間超過總時間後，停止插值
            if (currentTime >= duration)
            {
                enabled = false;
            }
        }

        Vector3 Linear(float t)
        {
            return startValue + (endValue - startValue) * t;
        }

        // 二次曲線Ease函數（EaseInOut）
        float EaseInOutQuad(float t)
        {
            return t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t;
        }

        // 三次曲線Ease函數（EaseInOut）
        float EaseInOutCubic(float t)
        {
            return t < 0.5f ? 4 * t * t * t : (t - 1) * (2 * t - 2) * (2 * t - 2) + 1;
        }

        // 彈跳效果
        float Bounce(float t)
        {
            if (t < 1 / 2.75f)
            {
                return 7.5625f * t * t;
            }
            else if (t < 2 / 2.75f)
            {
                t -= 1.5f / 2.75f;
                return 7.5625f * t * t + 0.75f;
            }
            else if (t < 2.5f / 2.75f)
            {
                t -= 2.25f / 2.75f;
                return 7.5625f * t * t + 0.9375f;
            }
            else
            {
                t -= 2.625f / 2.75f;
                return 7.5625f * t * t + 0.984375f;
            }
        }

        // 彈簧效果
        Vector3 Spring(float t)
        {
            t = Mathf.Clamp01(t);
            float result = Mathf.Pow(2, -10 * t) * Mathf.Sin((t - 0.075f) * (2 * Mathf.PI) / 0.3f) + 1;
            return startValue + (endValue - startValue) * result;
        }

        // 線性插值函數
        Vector3 Lerp(Vector3 start, Vector3 end, float t)
        {
            return start + (end - start) * t;
        }
    }
}