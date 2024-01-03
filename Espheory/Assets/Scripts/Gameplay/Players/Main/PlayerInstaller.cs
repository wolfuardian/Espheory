#region

using Eos.Gameplay.Players.Handler;
using Eos.Utils.Debug;
using Zenject;

#endregion

namespace Eos.Gameplay.Players.Main
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
            Container.BindInterfacesTo<CharacterHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerInputDebugger>().AsSingle();
        }

        #endregion
    }
}