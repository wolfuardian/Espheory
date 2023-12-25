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
            Container.Bind<InputState>().AsSingle();
            Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerCameraHandler>().AsSingle();
        }

        #endregion
    }
}