using System;
using Zenject;

namespace Espheory
{
    // [CreateAssetMenu(menuName = "Anteos/Game Settings")]

    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public EnemySpawner.Settings EnemySpawner;
        public GameInstaller.Settings GameInstaller;
        public EnemySettings Enemy;

        [Serializable]
        public class EnemySettings
        {
            public EnemyCommonSettings EnemyCommonSettings;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(EnemySpawner);
            Container.BindInstance(GameInstaller);

            Container.BindInstance(Enemy.EnemyCommonSettings);
        }
    }
}
