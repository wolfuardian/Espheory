using Zenject;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Navigate.Scripts
{
    internal interface IAgentNavigator
    {
        void Navigate(Transform target);
    }

    public class AgentNavigator : ITickable, IAgentNavigator
    {
        [Inject(Id = "PlayerNav")]
        private NavMeshAgent navMeshAgent;

        [Inject]
        private INavService navService;

        public void Tick()
        {
            if (navService.IsNavigateNext())
            {
                Navigate(navService.GetNextTarget());
            }
        }

        public void Navigate(Transform target)
        {
            if (navMeshAgent == null)
            {
                return;
            }

            navMeshAgent.destination = target.position;
        }
    }
}
