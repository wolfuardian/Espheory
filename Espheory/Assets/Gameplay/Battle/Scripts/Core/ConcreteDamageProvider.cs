using System;
using UnityEngine;

namespace Gameplay.Battle.Core
{
    public interface IDamageProvider
    {
        float               Health { get; }
        void                StartDamage();
        event Action<float> OnHealthChanged;
    }

    public class ConcreteDamageProvider : IDamageProvider
    {
        public float Health { get; private set; } = 100f;

        public event Action<float> OnHealthChanged;

        public void StartDamage()
        {
            Health -= 10f; // 減少 10 點血量
            if (Health < 0) Health = 0;

            Debug.Log($"Player health: {Health}");
            OnHealthChanged?.Invoke(Health); // 當健康值變化時觸發事件
        }
    }
    
    
}
