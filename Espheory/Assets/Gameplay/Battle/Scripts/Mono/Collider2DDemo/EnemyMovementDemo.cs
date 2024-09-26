using UnityEngine;

namespace Gameplay.Battle.Mono.Collider2DDemo
{
    public class EnemyMovementDemo : MonoBehaviour
    {
        [SerializeField] private GameObject m_Target;

        [SerializeField] private float m_Speed = 1.0f;

        private void Update()
        {
            if (m_Target != null)
            {
                Vector3 direction = m_Target.transform.position - transform.position;
                transform.position += direction.normalized * m_Speed * Time.deltaTime;
            }
        }
    }
}
