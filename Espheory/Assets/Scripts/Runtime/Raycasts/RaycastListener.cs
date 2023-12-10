using System;
using Eos.Events.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Eos.Runtime.Raycasts
{
    public class RaycastListener : MonoBehaviour
    {
        [SerializeField] private CameraRaycastEventChannelSO cameraRaycastEventChannelSO;
        [SerializeField] private UnityEvent<string> onEventRaisedString;
        [SerializeField] private UnityEvent<GameObject> onEventRaisedGameObject;


        private void OnEnable()
        {
            if (cameraRaycastEventChannelSO != null)
                cameraRaycastEventChannelSO.OnEventRaised += Respond;
        }

        private void OnDisable()
        {
            if (cameraRaycastEventChannelSO != null)
                cameraRaycastEventChannelSO.OnEventRaised -= Respond;
        }

        private void Respond(GameObject go)
        {
            if (go != null)
            {
                onEventRaisedString?.Invoke(go.name);
                onEventRaisedGameObject?.Invoke(go);
            }
            else
            {
                onEventRaisedString?.Invoke("null");
            }
        }
    }
}