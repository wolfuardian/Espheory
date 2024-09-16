using UnityEngine;
using Zenject;

namespace Gameplay.Nav.Core
{
    public interface INavService
    {
        // void Target(Transform target);

        void      Navigate(Transform target);
        bool      IsNavigateNext();
        bool      SetIsNavigateNext();
        Transform GetNextTarget();
    }

    public class NavService : INavService
    {
        [Inject]
        private IAgentNavigator agentNavigator;

        [Inject]
        private INavState navState;

        // public void Target(Transform target) => agentNavigator.Target(target);

        public void      Navigate(Transform target) => agentNavigator.Navigate(target);
        public bool      IsNavigateNext()           => navState.IsNavigateNext;
        public bool      SetIsNavigateNext()        => navState.IsNavigateNext = true;
        public Transform GetNextTarget()            => navState.GetNextTarget;
    }
}
