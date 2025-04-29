using Gameplay.CameraRaycast.Scripts.Core;
using Gameplay.Input.Core;
using UnityEngine;
using Zenject;

namespace Gameplay.Nav.Core
{
    public interface INavService
    {
        // void Target(Transform target);

        void    Navigate(Vector3 target);
        bool    IsNavigateNext();
        bool    SetIsNavigateNext();
        Vector3 GetNextTarget();
    }

    public class NavService : INavService
    {
        [Inject] private IAgentNavigator agentNavigator;

        [Inject] private INavState navState;

        [Inject] private IInputState inputState;

        [Inject] private ICursor3D cursor3D;

        // public void Target(Transform target) => agentNavigator.Target(target);

        public void Navigate(Vector3 target) => agentNavigator.Navigate(target);
        public bool IsNavigateNext()         => inputState.PerformingSelect == 1;
        public bool SetIsNavigateNext()      => navState.IsNavigateNext = true;

        public Vector3 GetNextTarget() => cursor3D.Position;
    }
}
