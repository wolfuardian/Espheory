using Gameplay.CameraRaycast.Scripts.Core;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay.Nav.Core
{
    public interface IAgentNavigator
    {
        void Navigate(Vector3 target);
    }

    public class AgentNavigator : ITickable, IAgentNavigator
    {
        [Inject(Id = "PlayerNav")]
        private NavMeshAgent navMeshAgent;

        [Inject] private INavService navService;

        [Inject] private ICursor3D cursor3D;

        public void Tick()
        {
            if (navService.IsNavigateNext())
            {
                Navigate(navService.GetNextTarget());
            }
        }

        public void Navigate(Vector3 target)
        {
            if (navMeshAgent == null)
            {
                return;
            }

            navMeshAgent.destination = target;
        }
    }
}
