#region

using Zenject;
using Eos.Gameplay.Context.Scene;

#endregion

namespace Eos.Gameplay.Battle.Main
{
    public class BattleInstaller : MonoInstaller
    {
        #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<ACursor>().FromComponentInHierarchy().AsSingle();
        }

        #endregion
    }
}