using UniRx;
using System;
using Zenject;

namespace Gameplay.Battle.Core
{
    public class DamageHandler : IInitializable, IDisposable
    {
        [Inject] private readonly IDamageProvider damageProvider;
        private readonly          float           damageInterval;
        private                   IDisposable     playerDamageSubscription;
        private                   IDisposable     enemyDamageSubscription;

        protected private IDamageDealer damageDealer;

        public DamageHandler(float damageInterval)
        {
            this.damageInterval = damageInterval;
        }

        public void Initialize()
        {
            // 在初始化時並不立即開始傷害，會等待外部通知
        }

        // 當需要開始傷害時，訂閱 UniRx 來進行傷害
        public void StartPlayerDamage()
        {
            StopPlayerDamage(); // 確保不會重複啟動

            playerDamageSubscription = Observable.Interval(TimeSpan.FromSeconds(damageInterval))
                .Subscribe(_ =>
                {
                    damageDealer.DealDamage(10);
                });
        }

        // 停止傷害
        public void StopPlayerDamage()
        {
            playerDamageSubscription?.Dispose();
            playerDamageSubscription = null;
        }

        public void Dispose()
        {
            StopPlayerDamage();
        }
    }
}
