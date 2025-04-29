using System;
using UnityEngine;
using Zenject;

namespace Espheory
{
    public class GameInstaller : MonoInstaller
    {
        [Inject] Settings _settings = null;

        public override void InstallBindings()
        {
            // Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle();

            // Container.BindFactory<string, EnemyFacade, EnemyFacade.Factory>()
            //     .FromPoolableMemoryPool<string, EnemyFacade, EnemyFacadePool>(poolBinder => poolBinder
            //         .WithInitialSize(5)
            //         .FromSubContainerResolve()
            //         .ByNewPrefabInstaller<EnemyInstaller>(_settings.EnemyFacadePrefab)
            //         .UnderTransformGroup("Enemies"));

            Container.BindFactory<float, ProjectileTypes, Projectile, Projectile.Factory>()
                .FromPoolableMemoryPool<float, ProjectileTypes, Projectile, ProjectilePool>(poolBinder => poolBinder
                    .WithInitialSize(20)
                    .FromComponentInNewPrefab(_settings.ProjectilePrefab)
                    .UnderTransformGroup("Projectiles"));

            Container.BindFactory<float, ExplosionTypes, Explosion, Explosion.Factory>()
                .FromPoolableMemoryPool<float, ExplosionTypes, Explosion, ExplosionPool>(poolBinder => poolBinder
                    .WithInitialSize(4)
                    .FromComponentInNewPrefab(_settings.ExplosionPrefab)
                    .UnderTransformGroup("Explosions"));
            
            GameSignalsInstaller.Install(Container);
        }

        [Serializable]
        public class Settings
        {
            public GameObject EnemyFacadePrefab;
            public GameObject ProjectilePrefab;
            public GameObject ExplosionPrefab;
        }

        class EnemyFacadePool : MonoPoolableMemoryPool<string, IMemoryPool, EnemyFacade>
        {
        }

        class ProjectilePool : MonoPoolableMemoryPool<float, ProjectileTypes, IMemoryPool, Projectile>
        {
        }

        class ExplosionPool : MonoPoolableMemoryPool<float, ExplosionTypes, IMemoryPool, Explosion>
        {
        }
    }
}
