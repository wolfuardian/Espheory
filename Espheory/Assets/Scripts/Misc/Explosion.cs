using UnityEngine;
using Zenject;

namespace Espheory
{
    public enum ExplosionTypes
    {
        Small,
        Medium,
        Large
    }

    public class Explosion : MonoBehaviour, IPoolable<float, ExplosionTypes, IMemoryPool>
    {
        public void OnSpawned(float radius, ExplosionTypes explosionType, IMemoryPool pool)
        {
        }

        public void OnDespawned()
        {
        }

        public class Factory : PlaceholderFactory<float, ExplosionTypes, Explosion>
        {
        }
    }
}
