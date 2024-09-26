using Zenject;
using UnityEngine;
using Gameplay.Battle.Core;

namespace Gameplay.Battle.Mono
{
    public class DamageTriggerZone : MonoBehaviour
    {
        [Inject] private DamageTriggerService damageTriggerService;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Player enter");

            if (other.CompareTag("Player"))
            {
                Debug.Log("Player enter");
                damageTriggerService.OnPlayerEnter();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player exit");
                damageTriggerService.OnPlayerExit();
            }
        }
    }
}
