using Zenject;
using Gameplay.Input.Core;
using Gameplay.CameraRaycast.Scripts.Core;

namespace Gameplay.CameraRaycast.Installer
{
    public class CameraRaycastInstaller : MonoInstaller
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
        }
    }
}
