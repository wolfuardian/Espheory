using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Espheory
{
    public class EnemySpawner : ITickable, IInitializable
    {
        readonly EnemyFacade.Factory _enemyFactory;
        readonly SignalBus _signalBus;
        readonly Settings _settings;

        [Inject] List<SpawnPoint> _spawnPoints;

        int _enemyCount;

        public EnemySpawner(
            Settings settings,
            SignalBus signalBus,
            EnemyFacade.Factory enemyFactory)
        {
            _signalBus = signalBus;
            _settings = settings;
            _enemyFactory = enemyFactory;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<EnemyKilledSignal>(OnEnemyKilled);
            _spawnPoints.ForEach(spawnPoint =>
            {
                SpawnEnemy(spawnPoint.transform.position);
            });
        }

        void OnEnemyKilled()
        {
            // Handle enemy killed logic here
            Debug.Log("Enemy killed");
            _enemyCount--;
        }

        public void Tick()
        {
            if (_enemyCount < _settings.EnemiesAmount)
            {
                // SpawnEnemy();
                _enemyCount++;
            }
        }

        void SpawnEnemy(Vector3 spawnPosition)
        {
            // Logic to spawn an enemy
            // var enemyFacade = _enemyFactory.Create(accuracy, speed);

            var enemyFacade = _enemyFactory.Create("enemyaaa");
            enemyFacade.Position = spawnPosition;

            // Debug.Log("Enemy spawned");
        }

        [Serializable]
        public class Settings
        {
            public int EnemiesAmount;
        }
    }
}
