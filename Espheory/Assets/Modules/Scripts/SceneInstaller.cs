using Zenject;

namespace Modules.Scripts
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(IInputState)).To<InputState>().AsSingle();
            Container.Bind(typeof(IAction), typeof(ITickable)).To<ActionController>().AsSingle();
            Container.Bind(typeof(IActionService)).To<ActionService>().AsSingle();
            Container.Bind(typeof(ITickable)).To<PlayerController>().AsSingle();
            Container.Bind(typeof(IKeyTracker), typeof(ITickable)).To<InputTracker>().AsSingle();
            Container.Bind(typeof(IKeyboard)).To<Keyboard>().AsSingle();
            Container.Bind(typeof(IInputHandler), typeof(ITickable)).To<InputHandler>().AsSingle();
            Container.Bind(typeof(InputMapper.IPlayerActions), typeof(IInputReader)).To<InputReader>().AsSingle();
        }
    }
}
