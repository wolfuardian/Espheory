using Gameplay.Nav.Core;
using Zenject;

namespace Gameplay.Nav.Installers
{
    public class NavInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(INavState)).To<NavState>().AsSingle();
            Container.Bind(typeof(IAgentNavigator), typeof(ITickable)).To<AgentNavigator>().AsSingle();
            Container.Bind(typeof(INavService)).To<NavService>().AsSingle();
        }
    }
}
