#region

using Eos.Gameplay.Player.Handler;
using Eos.Gameplay.Player.Mono;
using Eos.Utils.Debug;
using Zenject;

#endregion

namespace Eos.Gameplay.Player.Main
{
    public class PlayerInstaller : MonoInstaller
    {
        #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<MPlayer>().FromComponentInHierarchy().AsSingle();
            Container.Bind<MCharacter>().FromComponentInHierarchy().AsSingle();
            Container.Bind<MCameraPitchYaw>().FromComponentInHierarchy().AsSingle();

            Container.BindInterfacesTo<MessageDisplay>().FromComponentInHierarchy().AsSingle();
            Container.Bind<InputState>().AsSingle();
            Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
            Container.BindInterfacesTo<CameraHandler>().AsSingle();
            Container.BindInterfacesTo<CharacterHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerInputDebugger>().AsSingle();
        }

        #endregion
    }
}