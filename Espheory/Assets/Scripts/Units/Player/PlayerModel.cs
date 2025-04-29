using UnityEngine;
using UnityEngine.AI;

namespace Espheory
{
    public interface IPlayer
    {
        Vector3 Position { get; }
        Vector3 Destination { set; }
        Vector3 GetDestination(Vector2 viewportPointer);
    }

    public class Player : IPlayer
    {
        readonly Camera _camera;
        readonly Rigidbody _rigidbody;
        readonly NavMeshAgent _navMeshAgent;

        Vector3 _destination;

        public Player(
            Camera camera,
            Rigidbody rigidbody,
            NavMeshAgent navMeshAgent)
        {
            _camera = camera;
            _rigidbody = rigidbody;
            _navMeshAgent = navMeshAgent;
        }

        public Vector3 Direction
        {
            get
            {
                return _rigidbody.transform.forward;
            }
            set
            {
                if (value == Vector3.zero) return;
                _rigidbody.transform.forward = value;
            }
        }
        public Vector3 Position
        {
            get
            {
                return _rigidbody.position;
            }
        }
        public Vector3 Destination
        {
            get
            {
                return _navMeshAgent.destination;
            }
            set
            {
                _navMeshAgent.destination = value;
            }
        }

        public Vector3 GetDestination(Vector2 viewportPointer)
        {
            var ray = _camera.ScreenPointToRay(new Vector3(viewportPointer.x, viewportPointer.y, 0));
            if (Physics.Raycast(ray, out var hit))
            {
                _destination = hit.point;
            }
            return _destination;
        }
    }
}
