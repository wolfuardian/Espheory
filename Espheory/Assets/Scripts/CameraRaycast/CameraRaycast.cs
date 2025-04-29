using Zenject;
using Gameplay.Input.Core;
using UnityEngine;

namespace Gameplay.CameraRaycast.Scripts.Core
{
    public interface ICursor3D
    {
        Vector3 Position { get; set; }
    }

    public class Cursor3D : ICursor3D
    {
        public Vector3 Position { get; set; }
    }

    public interface ICamera
    {
        UnityEngine.Camera GetRef();
        Vector3            ScreenToWorldPoint(Vector2 screenPosition);

        Vector3 Position { get; }
    }

    public class Camera : ICamera
    {
        [Inject(Id = "MainCamera")]
        private UnityEngine.Camera camera;

        public UnityEngine.Camera GetRef() => camera;

        public Vector3 ScreenToWorldPoint(Vector2 screenPosition)
        {
            var ray = camera.ScreenPointToRay(new Vector3(screenPosition.x, screenPosition.y, 0));

            if (Physics.Raycast(ray, out var hit))
            {
                return hit.point;
            }

            return Vector3.zero;
        }

        public Vector3 Position => camera.transform.position;
    }

    public interface ICursor3DHandler
    {
        ICursor3D GetCursor();
    }

    public class Cursor3DHandler : ICursor3DHandler, ITickable
    {
        [Inject] private IInputState inputState;

        [Inject] private IViewportService viewport;

        [Inject] private ICursor3D cursor3D;

        public void Tick()
        {
            cursor3D.Position = viewport.GetCamera().ScreenToWorldPoint(inputState.PointerPosition);
        }

        public ICursor3D GetCursor() => cursor3D;
    }

    public interface IViewportService
    {
        ICursor3D GetCursor3D();
        ICamera   GetCamera();
    }

    public class ViewportService : IViewportService
    {
        [Inject] public ICursor3D Cursor3D { get; }
        [Inject] public ICamera   Camera   { get; }

        public ICursor3D GetCursor3D() => Cursor3D;
        public ICamera   GetCamera()   => Camera;
    }
}
