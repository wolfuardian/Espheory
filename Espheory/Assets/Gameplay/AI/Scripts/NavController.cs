using Zenject;
using UnityEngine.AI;

namespace Gameplay.AI.Scripts
{
    internal interface INavController
    {
        void Target();
        void Navigate();
    }

    public class NavController : ITickable, INavController
    {
        [Inject(Id = "PlayerNav")]
        private NavMeshAgent m_NavMeshAgent;

        public void Tick()
        {
        }

        public void Target()
        {
        }

        public void Navigate()
        {
        }
    }
}
