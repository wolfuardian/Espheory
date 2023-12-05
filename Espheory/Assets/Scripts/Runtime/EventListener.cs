using Eos.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Eos.Scripts.Runtime
{
    public class EventListener : MonoBehaviour
    {
        public GameEvent gameEvent;
        public UnityEvent response;

        private void OnEnable()
        {
            gameEvent.RegisterListener(OnEventRaised);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(OnEventRaised);
        }

        private void OnEventRaised()
        {
            response.Invoke();
        }
    }
}