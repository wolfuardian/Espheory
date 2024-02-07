using Zenject;
using Eos.Gameplay.Input;

namespace Eos.Gameplay.Installer
{
    public class PlayerControllerInstaller : MonoInstaller
    {
        #region Zenject

        public override void InstallBindings()
        {
            Container.Bind<InputState>().AsSingle();
        }

        #endregion
    }
}