using System.Collections;
using UnityEngine;
using Zenject;

namespace Gameplay.Stat.Core
{
    public interface IDamageProvider
    {
        int  Health { get; set; }
        void StartDamage();
        void StopDamage();
    }

    public class DamageProvider : IDamageProvider, IInitializable
    {
        // [Inject(Id = "DamageTrigger")]
        // private Collider collider;

        public void Initialize()
        {
            // collider.
        }

        public int Health { get; set; } = 100;

        public void StartDamage()
        {
            Health -= 10;
        }

        public void StopDamage()
        {
        }
    }
}
