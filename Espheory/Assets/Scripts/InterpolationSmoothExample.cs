using UnityEngine;

namespace Math
{
    public class InterpolationSmoothExample : MonoBehaviour
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

            // 計算插值比例（0到1之間）並使用二次曲線插值函數
            float t = Mathf.Clamp01(currentTime / duration);
            float easedT = EaseInOutQuad(t); // 使用二次曲線Ease函數

            // 使用插值函數計算中間值
            Vector3 interpolatedValue = Lerp(startValue, endValue, easedT);

            // 應用插值結果，例如移動物體
            transform.position = interpolatedValue;

            // 當時間超過總時間後，停止插值
            if (currentTime >= duration)
            {
                enabled = false;
            }
        }

        // 線性插值函數
        Vector3 Lerp(Vector3 start, Vector3 end, float t)
        {
            return start + (end - start) * t;
        }

        // 二次曲線Ease函數（EaseInOut）
        float EaseInOutQuad(float t)
        {
            return t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t;
        }
    }
}