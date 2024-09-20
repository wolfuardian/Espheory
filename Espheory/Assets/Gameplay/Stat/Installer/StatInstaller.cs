using Gameplay.CameraRaycast.Scripts.Core;
using Gameplay.Input.Core;
using Gameplay.Nav.Core;
using Gameplay.Stat.Core;
using Zenject;

namespace Gameplay.Stat.Installer
{
    public class StatInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(Controls.IPlayerActions)).To<InputReader>().AsSingle().NonLazy(); // NonLazy 一定要加上，否則不會被自動注入
            Container.Bind(typeof(IInputState)).To<InputState>().AsSingle();
            Container.Bind(typeof(IInputService)).To<InputService>().AsSingle();
            Container.Bind(typeof(IInputTrack),          typeof(ITickable)).To<InputTrack>().AsSingle();
            Container.Bind(typeof(IInputTrackPerformer), typeof(ITickable)).To<InputTrackPerformer>().AsSingle();

            // Container.Bind(typeof(ICursorStat)).To<CursorStat>().AsSingle();
            Container.Bind(typeof(ICursor3D)).To<Cursor3D>().AsSingle();
            Container.Bind(typeof(IViewportService)).To<ViewportService>().AsSingle();
            Container.Bind(typeof(ICamera)).To<Camera>().AsSingle();
            Container.Bind(typeof(ICursor3DHandler), typeof(ITickable)).To<Cursor3DHandler>().AsSingle();

            Container.Bind(typeof(INavState)).To<NavState>().AsSingle();
            Container.Bind(typeof(IAgentNavigator), typeof(ITickable)).To<AgentNavigator>().AsSingle();
            Container.Bind(typeof(INavService)).To<NavService>().AsSingle();

            // Container.Bind(typeof(IDamageProvider), typeof(IInitializable)).To<DamageProvider>().AsSingle();

            // 假設有一個具體的 DamageProvider 實作
            Container.Bind<IDamageProvider>().To<ConcreteDamageProvider>().AsSingle();

            // 綁定 DamageHandler，並提供一個傷害時間間隔參數
            Container.Bind<DamageHandler>()
                .AsSingle()
                .WithArguments(1f); // 每隔 1 秒造成一次傷害

            // 綁定 DamageTriggerService
            Container.Bind<DamageTriggerService>().AsSingle();
        }
    }
}
