using UnityEngine;
using UnityEngine.AI;

namespace Espheory
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField]
        MeshRenderer _renderer = null;

        [SerializeField]
        Collider _collider = null;

        [SerializeField]
        Rigidbody _rigidBody = null;

        [SerializeField]
        NavMeshAgent _navMeshAgent = null;

        public Vector3 Position
        {
            get { return _rigidBody.transform.position; }
            set { _rigidBody.transform.position = value; }
        }

        public void Idle()
        {
            _renderer.material.color = Color.white;
        }

        public void Alert()
        {
            _renderer.material.color = Color.yellow;
        }

        public void Attack()
        {
            _renderer.material.color = Color.red;
        }

        public void Move(Vector3 newPosition)
        {
            _navMeshAgent.destination = newPosition;
            _navMeshAgent.isStopped = false;
        }

        public void StopMove()
        {
            _navMeshAgent.isStopped = true;
        }
    }
}
