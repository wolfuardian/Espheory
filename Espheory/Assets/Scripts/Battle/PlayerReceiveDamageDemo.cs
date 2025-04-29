using Gameplay.Battle.Core;
using UnityEngine;
using Zenject;

namespace Gameplay.Battle.Mono.Collider2DDemo
{
    public class PlayerReceiveDamageDemo : MonoBehaviour
    {
        [SerializeField] private int m_Health = 100;

        [Inject] private IPlayerHealth m_PlayerHealth;

        private void Awake()
        {
            m_PlayerHealth.SetHealth(m_Health);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // // 如果碰撞到的物件有 DamageDealerDemo 這個 component
            // if (other.TryGetComponent(out DamageDealer damageDealer))
            // {
            //     // 扣血
            //     TakeDamage(damageDealer.Damage);
            // }
        }
    }
}
