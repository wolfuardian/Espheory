using Gameplay.Stat.Core;
using UnityEngine;
using Zenject;

namespace Gameplay.Stat.Mono
{
    public class DamageTriggerZone : MonoBehaviour
    {
        [Inject] private DamageTriggerService damageTriggerService;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player enter");
                damageTriggerService.OnPlayerEnter();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player exit");
                damageTriggerService.OnPlayerExit();
            }
        }
    }
}
