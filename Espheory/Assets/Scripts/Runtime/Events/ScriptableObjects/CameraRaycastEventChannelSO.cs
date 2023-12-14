using UnityEngine;
using UnityEngine.Events;

namespace Eos.Runtime.Events.ScriptableObjects
{
    /// <summary>
    /// 這個類別用於有一個 CameraRaycastDataSO 參數的事件。
    /// <para>範例: 攝影機射線事件，其中 CameraRaycastDataSO 是射線資料。</para>
    /// </summary>
    [CreateAssetMenu(menuName = "Events/Camera Raycast Event Channel")]
    public class CameraRaycastEventChannelSO : ScriptableObject
    {
        public UnityAction<GameObject> OnEventRaised;

        public void RaiseEvent(GameObject value)
        {
            OnEventRaised?.Invoke(value);
        }
    }
}