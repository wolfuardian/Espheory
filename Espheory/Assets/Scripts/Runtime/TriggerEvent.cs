using Eos.Scripts.ScriptableObjects;
using UnityEngine;

namespace Eos.Scripts.Runtime
{
    public class TriggerEvent : MonoBehaviour
    {
        public GameEvent gameEventA;
        public GameEvent gameEventB;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameEventA.Raise();
            }

            if (Input.GetMouseButtonDown(1))
            {
                gameEventB.Raise();
            }
        }
    }
}