using Math;
using UnityEngine;

public class InterpolationExample : MonoBehaviour
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

        var interpolatedValue = VInterp.Linear(startValue, endValue, t);


        transform.position = interpolatedValue;

        if (currentTime >= duration)
        {
            enabled = false;
        }
    }

    Vector3 Linear(float t)
    {
        return startValue + (endValue - startValue) * t;
    }

    float EaseInOutQuad(float t)
    {
        return t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t;
    }

    float EaseInOutCubic(float t)
    {
        return t < 0.5f ? 4 * t * t * t : (t - 1) * (2 * t - 2) * (2 * t - 2) + 1;
    }

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

    Vector3 Spring(float t)
    {
        t = Mathf.Clamp01(t);
        float result = Mathf.Pow(2, -10 * t) * Mathf.Sin((t - 0.075f) * (2 * Mathf.PI) / 0.3f) + 1;
        return startValue + (endValue - startValue) * result;
    }

    Vector3 Lerp(Vector3 start, Vector3 end, float t)
    {
        return start + (end - start) * t;
    }
}