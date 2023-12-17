using UnityEngine;
using UnityEngine.Events;

namespace Eos.Runtime.Events.ScriptableObjects.Default
{
    [CreateAssetMenu(menuName = "Events/Void Event Channel")]
    public class VoidEventChannelSO : ScriptableObject
    {
        public UnityAction onEventRaised;

        public void RaiseEvent()
        {
            onEventRaised?.Invoke();
        }
    }
}