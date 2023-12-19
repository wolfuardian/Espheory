#region

using Eos.Runtime.Mouse;
using Zenject;

#endregion

namespace Eos.Players.Main
{
    public class PlayerCharacterInstaller : MonoInstaller
    {
        #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<InputReader>().AsSingle();
        }

        #endregion
    }
}