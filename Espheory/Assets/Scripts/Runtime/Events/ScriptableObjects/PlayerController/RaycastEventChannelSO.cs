using UnityEngine;
using UnityEngine.Events;

namespace Eos.Runtime.Events.ScriptableObjects.PlayerController
{
    [CreateAssetMenu(menuName = "Events/Raycast Event Channel")]
    public class RaycastEventChannelSO : ScriptableObject
    {
        public UnityAction<RaycastHit> onRaycastHit;
        public void RaiseRaycastHitEvent(RaycastHit value) => onRaycastHit?.Invoke(value);
    }
}