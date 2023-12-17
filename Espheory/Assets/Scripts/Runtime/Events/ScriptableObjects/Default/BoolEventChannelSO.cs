using UnityEngine;
using UnityEngine.Events;

namespace Eos.Runtime.Events.ScriptableObjects.Default
{
    [CreateAssetMenu(menuName = "Events/Bool Event Channel")]
    public class BoolEventChannelSO : ScriptableObject
    {
        public UnityAction<bool> onEventRaised;

        public void RaiseEvent(bool value)
        {
            onEventRaised?.Invoke(value);
        }
    }
}