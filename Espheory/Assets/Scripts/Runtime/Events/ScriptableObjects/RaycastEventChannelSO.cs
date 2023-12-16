using UnityEngine;
using UnityEngine.Events;

namespace Eos.Runtime.Events.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Events/Raycast Event Channel")]
    public class RaycastEventChannelSO : ScriptableObject
    {
        public UnityAction onRaycastHit;
        public UnityAction<GameObject> onRaycastHitGameObject;
        public void RaiseRaycastHitEvent() => onRaycastHit?.Invoke();
        public void RaiseRaycastHitGameObjectEvent(GameObject value) => onRaycastHitGameObject?.Invoke(value);
    }
}