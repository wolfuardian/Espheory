using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Espheory
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField]
        Settings _settings = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerInputReader>().AsSingle().NonLazy(); // NonLazy 一定要加上，否則不會被自動注入

            Container.BindInterfacesTo<Player>().AsSingle()
                .WithArguments(_settings.Camera, _settings.Rigidbody, _settings.NavMeshAgent);

            Container.BindInterfacesTo<PlayerNavigator>().AsSingle();

            Container.BindInterfacesTo<PlayerInputState>().AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public Camera Camera;
            public Rigidbody Rigidbody;
            public NavMeshAgent NavMeshAgent;
        }
    }
}
