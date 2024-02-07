using Zenject;
using Eos.Gameplay.Context.Scene;

namespace Eos.Gameplay.Battle.Main
{
    public class SceneInstaller : MonoInstaller
    {
        #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<ACursor>().FromComponentInHierarchy().AsSingle();
        }

        #endregion
    }
}