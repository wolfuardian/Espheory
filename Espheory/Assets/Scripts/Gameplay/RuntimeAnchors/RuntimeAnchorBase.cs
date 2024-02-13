using UnityEngine;
using UnityEngine.Events;
using Eos.Core.Attribute.ReadOnlyAttribute;

namespace Eos.Gameplay.RuntimeAnchors
{
    public class RuntimeAnchorBase<T> : ScriptableObject where T : Object
    {
        public UnityAction onAnchorProvided;

        [Header("Debug")] [ReadOnly] public bool
            isSet; // Any script can check if the transform is null before using it, by just checking this bool

        [ReadOnly] [SerializeField] private T _value;

        public T Value => _value;

        public void Provide(T value)
        {
            if (value == null)
            {
                Debug.LogError("A null value was provided to the " + name + " runtime anchor.");
                return;
            }

            _value = value;
            isSet  = true;

            onAnchorProvided?.Invoke();
        }

        public void Unset()
        {
            _value = null;
            isSet  = false;
        }

        private void OnDisable()
        {
            Unset();
        }
    }
}