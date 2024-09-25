using System;
using Gameplay.Stat.Core;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Gameplay.Stat.Mono
{
    public class UpdateHealthUI : MonoBehaviour
    {
        [SerializeField] private UnityEvent<string> m_OnHealthChanged;

        [Inject] IDamageProvider damageProvider;

        private void OnEnable()
        {
            damageProvider.OnHealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            damageProvider.OnHealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(float value)
        {
            m_OnHealthChanged.Invoke(value.ToString());
        }
    }
}
