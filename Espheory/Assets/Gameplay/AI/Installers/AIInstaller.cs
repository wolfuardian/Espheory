using Gameplay.AI.Scripts;
using Gameplay.Input;
using Zenject;

namespace Gameplay.AI.Installers
{
    public class AIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(IActionTracker)).To<ActionTracker>().AsSingle();
            Container.Bind(typeof(IActionController), typeof(ITickable)).To<ActionController>().AsSingle();
            Container.Bind(typeof(IInputState)).To<InputState>().AsSingle();
            Container.Bind(typeof(IActionService)).To<ActionService>().AsSingle();
            Container.Bind(typeof(ITickable)).To<PlayerController>().AsSingle();
            Container.Bind(typeof(IKeyTracker), typeof(ITickable)).To<InputTracker>().AsSingle();
            Container.Bind(typeof(IKeyboard)).To<Keyboard>().AsSingle();
            Container.Bind(typeof(IInputHandler),              typeof(ITickable)).To<InputHandler>().AsSingle();
            Container.Bind(typeof(InputMapper.IPlayerActions), typeof(IInputReader)).To<InputReader>().AsSingle();

            Container.Bind(typeof(INavController), typeof(ITickable)).To<NavController>().AsSingle();
            Container.Bind(typeof(INavService),    typeof(ITickable)).To<NavService>().AsSingle();
        }
    }
}
