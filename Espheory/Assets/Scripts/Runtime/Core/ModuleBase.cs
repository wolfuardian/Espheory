using UnityEngine;

namespace Eos.Runtime.Core
{
    public class ModuleBase: MonoBehaviour, ITick
    {
        public virtual void Tick()
        {
        }
    }
}