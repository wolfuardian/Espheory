using UnityEngine;
using Eos.Gameplay.Context.Actor.ScriptableObjects;

namespace Eos.Gameplay.Context.Actor
{
    [DisallowMultipleComponent]
    public class ActorInstance : MonoBehaviour
    {
        [SerializeField] private GameObject _instance;
        [SerializeField] private ActorSO    _actor;

        public GameObject Instance => _instance;
        public ActorSO    Actor    => _actor;
    }
}