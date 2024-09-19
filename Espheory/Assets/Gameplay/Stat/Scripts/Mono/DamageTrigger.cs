using System.Collections;
using Gameplay.Stat.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.Stat.Mono
{
    public class DamageTrigger : MonoBehaviour
    {
        [Inject] private IDamageProvider damageProvider;

        [SerializeField] private Text m_Text;

        private bool  isTakingDamage = false;
        private float damageInterval = 1f;

        private void Start()
        {
            // 訂閱健康值變更的事件
            // damageProvider.OnHealthChanged += UpdateHealthText;
            UpdateHealthText(damageProvider.Health);
        }

        private void Update()
        {
            m_Text.text = damageProvider.Health.ToString();
            UpdateHealthText(damageProvider.Health);
        }

        private void OnDestroy()
        {
            // 取消訂閱事件以避免記憶體洩漏
            // damageProvider.OnHealthChanged -= UpdateHealthText;
        }

        private void OnTriggerEnter(Collider other)
        {
            // 只在進入碰撞區時開始計算傷害，避免每幀都觸發
            if (other.CompareTag("Player") && !isTakingDamage)
            {
                StartCoroutine(TakeDamage());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            // 離開碰撞區停止傷害計算
            if (other.CompareTag("Player") && isTakingDamage)
            {
                StopCoroutine(TakeDamage());
                isTakingDamage = false;
            }
        }

        private void UpdateHealthText(float currentHealth)
        {
            // 當健康值變更時更新 UI
            m_Text.text = currentHealth.ToString();
        }

        private IEnumerator TakeDamage()
        {
            isTakingDamage = true;

            while (isTakingDamage)
            {
                damageProvider.StartDamage();
                yield return new WaitForSeconds(damageInterval);
            }
        }
    }
}
