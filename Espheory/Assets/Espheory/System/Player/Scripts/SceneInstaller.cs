using Zenject;

namespace Espheory.System.Player
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.Bind(typeof(IAction), typeof(ITickable)).To<ActionController>().AsSingle();
            Container.Bind<IActionService>().To<ActionService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle();
            Container.Bind(typeof(GameInput.IPlayerActions), typeof(IInputReader)).To<InputReader>().AsSingle();
        }
    }
}