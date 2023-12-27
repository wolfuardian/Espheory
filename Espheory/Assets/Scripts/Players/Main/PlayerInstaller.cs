#region

using Eos.Players.Handler;
using Zenject;

#endregion

namespace Eos.Players.Main
{
    public class PlayerInstaller : MonoInstaller
    {
        #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<LookAroundState>().AsSingle();
            Container.Bind<InputState>().AsSingle();
            Container.BindInterfacesTo<InputStateCooldown>().AsSingle();
            
            Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerCameraHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerCharacterHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerInputDebugger>().AsSingle();
        }

        #endregion
    }
}