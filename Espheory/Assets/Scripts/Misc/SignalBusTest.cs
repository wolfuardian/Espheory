using UnityEngine;

namespace Espheory
{
    public class SignalBusTest : MonoBehaviour
    {
        // [Inject] EnemyDeathHandler _enemyDeathHandler = null;

        public void DieTest()
        {
            // _enemyDeathHandler.Die();
            FindAnyObjectByType<EnemyFacade>().Die();
        }
    }
}
