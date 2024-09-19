using System;
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

        private bool shouldDamage = true;

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(TakeDamage());
            }
        }

        private void Update()
        {
            m_Text.text = damageProvider.Health.ToString();
        }

        private IEnumerator TakeDamage()
        {
            if (shouldDamage)
            {
                damageProvider.StartDamage();
                shouldDamage = !shouldDamage;
                yield return new WaitForSeconds(1);
                shouldDamage = !shouldDamage;
            }
        }
    }
}
