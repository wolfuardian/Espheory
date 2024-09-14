using Gameplay.Input.Scripts;
using Zenject;

namespace Gameplay.Input.Installer
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(Controls.IPlayerActions)).To<InputReader>().AsSingle().NonLazy();

            Container.Bind(typeof(IActionTracker)).To<ActionTracker>().AsSingle();
            Container.Bind(typeof(IActionController), typeof(ITickable)).To<ActionController>().AsSingle();
            Container.Bind(typeof(IInputState)).To<InputState>().AsSingle();
            Container.Bind(typeof(IActionService)).To<ActionService>().AsSingle();
            Container.Bind(typeof(ITickable)).To<PlayerController>().AsSingle();
            Container.Bind(typeof(IKeyTracker), typeof(ITickable)).To<InputTracker>().AsSingle();
            Container.Bind(typeof(IKeyboard)).To<Keyboard>().AsSingle();
            Container.Bind(typeof(IInputHandler), typeof(ITickable)).To<InputHandler>().AsSingle();

        }
    }
}
