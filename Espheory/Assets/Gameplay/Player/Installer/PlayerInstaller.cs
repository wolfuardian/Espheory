using Zenject;
using Gameplay.Input.Core;
using Gameplay.Player.Core;

namespace Gameplay.Player.Installer
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(Controls.IPlayerActions)).To<InputReader>().AsSingle().NonLazy(); // NonLazy 一定要加上，否則不會被自動注入
            Container.Bind(typeof(IInputState)).To<InputState>().AsSingle();
            Container.Bind(typeof(IInputService)).To<InputService>().AsSingle();
            Container.Bind(typeof(IInputTrack),          typeof(ITickable)).To<InputTrack>().AsSingle();
            Container.Bind(typeof(IInputTrackPerformer), typeof(ITickable)).To<InputTrackPerformer>().AsSingle();

            Container.Bind(typeof(ITickable)).To<PlayerController>().AsSingle();
        }
    }
}
