using Zenject;
using Gameplay.Input.Scripts;

namespace Gameplay.Input.Installer
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(IInputPerformer), typeof(ITickable)).To<InputPerformer>().AsSingle();
            Container.Bind(typeof(IInputFsm)).To<InputFsm>().AsSingle();
            Container.Bind(typeof(IInputService)).To<InputService>().AsSingle();
            Container.Bind(typeof(Controls.IPlayerActions)).To<InputReader>().AsSingle();
        }
    }
}
