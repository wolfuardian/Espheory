using System;
using UnityEngine;

namespace Eos.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewGameEvent", menuName = "Game Event", order = 51)]
    public class GameEvent : ScriptableObject
    {
        private Action _listeners = delegate { };

        public void Raise()
        {
            _listeners.Invoke();
        }

        public void RegisterListener(Action listener)
        {
            _listeners += listener;
        }

        public void UnregisterListener(Action listener)
        {
            _listeners -= listener;
        }
    }
}