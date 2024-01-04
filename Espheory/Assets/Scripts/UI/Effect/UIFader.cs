using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Eos.UI.Effect
{
    public class UIFader : MonoBehaviour
    {
        public  Image     targetImage;
        public  float     fadeInTime  = 1f;
        public  float     fadeOutTime = 1f;
        private float     _time;
        private Coroutine _fadeCoroutine;

        private void Start()
        {
            InitializeImage();
        }

        private void InitializeImage()
        {
            if (targetImage != null)
            {
                targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, 0f);
            }
        }

        public void TriggerFade(bool shouldFade)
        {
            if (!shouldFade) return;

            if (_fadeCoroutine != null)
            {
                StopCoroutine(_fadeCoroutine);
            }

            _time          = 0;
            _fadeCoroutine = StartCoroutine(FadeSequence());
        }

        private IEnumerator FadeSequence()
        {
            yield return StartCoroutine(FadeTo(1f, fadeInTime));
            yield return StartCoroutine(FadeTo(0f, fadeOutTime));
        }

        private IEnumerator FadeTo(float targetAlpha, float duration)
        {
            var startAlpha = targetImage.color.a;

            while (_time < duration)
            {
                var alpha = Mathf.Lerp(startAlpha, targetAlpha, _time / duration);
                targetImage.color =  new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, alpha);
                _time             += Time.deltaTime;
                yield return null;
            }

            targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, targetAlpha);
        }
    }
}