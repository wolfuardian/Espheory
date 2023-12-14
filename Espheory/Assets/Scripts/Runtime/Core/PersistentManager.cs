using UnityEngine;
using System.Collections.Generic;

namespace Eos.Runtime.Core
{
    public class PersistentManager : MonoBehaviour
    {
        public static PersistentManager instance { get; private set; }

        private readonly List<ITick> _actors = new();

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
        }


        public void Register(ITick tick)
        {
            _actors.Add(tick);
        }

        public void Unregister(ITick tick)
        {
            _actors.Remove(tick);
        }

        private void Update()
        {
            foreach (var actor in _actors)
            {
                actor.Tick();
            }
        }
    }
}