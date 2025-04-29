using System;
using UnityEngine;
using Zenject;

namespace Espheory
{
    public interface IEnemyFacade
    {
        Vector3 Position { get; }
    }

    public class EnemyFacade : MonoBehaviour, IPoolable<string, IMemoryPool>, IDisposable, IEnemyFacade
    {
        EnemyView _view;
        EnemyTunables _enemyTunables;
        IEnemyDeathHandler _deathHandler;
        IMemoryPool _pool;

        [Inject]
        public void Construct(
            EnemyView view,
            EnemyTunables enemyTunables,
            IEnemyDeathHandler deathHandler)
        {
            _view = view;
            _enemyTunables = enemyTunables;
            _deathHandler = deathHandler;
        }

        public Vector3 Position
        {
            get { return _view.Position; }
            set { _view.Position = value; }
        }

        public void Dispose()
        {
            _pool.Despawn(this);
        }

        public void Die()
        {
            _deathHandler.Die();
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public void OnSpawned(string enemyName, IMemoryPool pool)
        {
            _pool = pool;
            _enemyTunables.EnemyName = enemyName;
        }

        public class Factory : PlaceholderFactory<string, EnemyFacade>
        {
        }
    }
}
