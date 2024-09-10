using Zenject;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Modules.Scripts
{
    public class SwitchTarget : MonoBehaviour
    {
        // IInputReader inputReader;

        public Transform   m_Cursor;
        public Transform   m_CurrentTarget;
        public Transform[] m_Targets;

        void OnEnable()
        {
            // inputReader.OnTab += OnSwitchTarget;
        }

        void OnDisable()
        {
            // inputReader.OnTab -= OnSwitchTarget;
        }

        void OnSwitchTarget(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (m_Targets.Length == 0)
                {
                    return;
                }

                if (m_CurrentTarget == null)
                {
                    m_CurrentTarget = m_Targets[0];
                    return;
                }

                var currentIndex = System.Array.IndexOf(m_Targets, m_CurrentTarget);
                var nextIndex    = (currentIndex + 1) % m_Targets.Length;
                m_CurrentTarget = m_Targets[nextIndex];

                m_Cursor.position = m_CurrentTarget.position;
            }
        }
    }
}
