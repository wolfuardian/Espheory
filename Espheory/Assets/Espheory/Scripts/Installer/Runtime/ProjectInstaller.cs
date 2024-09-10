#region

using UnityEngine;
using Zenject;

#endregion

namespace Espheory.Installer.Runtime
{
    public class ProjectInstaller : MonoInstaller
    {
        #region Private Variables

        [SerializeField] private GameModeBase         GameModePrefab;
        [SerializeField] private PlayerControllerBase PlayerControllerPrefab;

        #endregion

        #region Public Methods

        public override void InstallBindings()
        {
            Application.targetFrameRate = 60;

            // Bind Modules of GameMode
            // Container.Bind<MainScreenMode>().FromComponentsInNewPrefab(GameModePrefab).AsSingle().NonLazy();
            // Container.Bind<JourneyMode>().FromComponentsInNewPrefab(GameModePrefab).AsSingle().NonLazy();
            // Container.Bind<ZenMode>().FromComponentsInNewPrefab(GameModePrefab).AsSingle().NonLazy();

            // Bind Modules of PlayerController
            // Container.Bind<InputHandler>().FromComponentsInNewPrefab(PlayerControllerPrefab).AsSingle().NonLazy();
            // Container.Bind<InputState>().FromComponentsInNewPrefab(PlayerControllerPrefab).AsSingle().NonLazy();
        }

        #endregion
    }

    public class InputState
    {
    }

    public class InputHandler
    {
    }

    public class ZenMode
    {
    }

    public class JourneyMode
    {
    }

    public class MainScreenMode
    {
    }
}