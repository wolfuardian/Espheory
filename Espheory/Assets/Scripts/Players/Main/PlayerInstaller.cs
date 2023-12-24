#region

using Eos.Logger.UI;
using Eos.Players.Handler;
using UnityEngine;
using Zenject;

#endregion

namespace Eos.Players.Main
{
    public class PlayerInstaller : MonoInstaller
    {
        #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
            Container.Bind<PlayerInputState>().AsSingle();
            Container.BindInterfacesTo<DebugUIHandler>().AsSingle();
        }

        #endregion
    }
}