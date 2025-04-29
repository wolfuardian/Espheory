using UnityEngine;
using Zenject;

namespace Espheory
{
    public enum ProjectileTypes
    {
        Bullet,
        Rocket,
        Grenade
    }

    public class Projectile : MonoBehaviour, IPoolable<float, ProjectileTypes, IMemoryPool>
    {
        public void OnSpawned(float damage, ProjectileTypes projectileType, IMemoryPool pool)
        {
        }

        public void OnDespawned()
        {
        }

        public class Factory : PlaceholderFactory<float, ProjectileTypes, Projectile>
        {
        }
    }
}
