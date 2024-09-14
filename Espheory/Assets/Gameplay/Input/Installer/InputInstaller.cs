using Zenject;
using Gameplay.Input.Core;

namespace Gameplay.Input.Installer
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(Controls.IPlayerActions)).To<InputReader>().AsSingle().NonLazy();

            Container.Bind(typeof(IInputState)).To<InputState>().AsSingle();

            Container.Bind(typeof(IInputService)).To<InputService>().AsSingle();
            Container.Bind(typeof(IInputRecorder), typeof(ITickable)).To<InputRecorder>().AsSingle();
            Container.Bind(typeof(IInputTracker),  typeof(ITickable)).To<InputTracker>().AsSingle();
        }
    }
}
