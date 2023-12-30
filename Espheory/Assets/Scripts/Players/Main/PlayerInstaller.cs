#region

using Eos.Players.Handler;
using Eos.Utils;
using Zenject;

#endregion

namespace Eos.Players.Main
{
    public class PlayerInstaller : MonoInstaller
    {
        #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MessageDisplay>().FromComponentInHierarchy().AsSingle();
            Container.Bind<InputState>().AsSingle();
            Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerCameraHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerCharacterHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerInputDebugger>().AsSingle();
        }

        #endregion
    }
}