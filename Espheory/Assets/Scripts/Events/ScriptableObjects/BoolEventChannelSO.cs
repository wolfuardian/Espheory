using UnityEngine;
using UnityEngine.Events;

namespace Eos.Events.ScriptableObjects
{
    /// <summary>
    /// 這個類別用於有一個 bool 參數的事件。
    /// <para>範例: 遊戲暫停事件，其中 bool 是遊戲是否暫停。</para>
    /// </summary>
    [CreateAssetMenu(menuName = "Events/Bool Event Channel")]
    public class BoolEventChannelSO : ScriptableObject
    {
        public UnityAction<bool> OnEventRaised;

        public void RaiseEvent(bool value)
        {
            OnEventRaised?.Invoke(value);
        }
    }
}