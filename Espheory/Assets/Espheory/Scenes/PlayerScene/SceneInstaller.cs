#region

using Espheory.Player;
using Zenject;

#endregion

namespace Espheory.PlayerScene
{
    public class SceneInstaller : MonoInstaller
    {
        #region Public Methods

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.Bind(typeof(IAction), typeof(ITickable)).To<ActionController>().AsSingle();
            Container.Bind<IActionService>().To<ActionService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle();
            Container.Bind(typeof(IKeyTracker),                typeof(ITickable)).To<InputKeyTracker>().AsSingle();
            Container.Bind(typeof(InputMapper.IPlayerActions), typeof(IInputReader)).To<InputReader>().AsSingle();
        }

        #endregion
    }
}