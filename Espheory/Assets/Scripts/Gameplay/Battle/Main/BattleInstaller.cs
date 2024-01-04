#region

using Eos.Gameplay.Context.Scene;
using Zenject;

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