using UnityEngine;
using UnityEngine.Events;

namespace Eos.Runtime.Events.ScriptableObjects.PlayerController
{
    [CreateAssetMenu(menuName = "Events/Camera Event Channel")]
    public class CameraEventChannelSO : ScriptableObject
    {
        public UnityAction<Camera> onCameraPossessed;

        public void RaiseCameraPossessedEvent(Camera value) => onCameraPossessed?.Invoke(value);
    }
}