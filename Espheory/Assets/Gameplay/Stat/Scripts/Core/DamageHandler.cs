using System;
using UniRx;
using Zenject;

namespace Gameplay.Stat.Core
{
    public class DamageHandler : IInitializable, IDisposable
    {
        [Inject] private readonly IDamageProvider damageProvider;
        private readonly          float           damageInterval;
        private                   IDisposable     damageSubscription;

        public DamageHandler(float damageInterval)
        {
            this.damageInterval = damageInterval;
        }

        public void Initialize()
        {
            // 在初始化時並不立即開始傷害，會等待外部通知
        }

        // 當需要開始傷害時，訂閱 UniRx 來進行傷害
        public void StartDamage()
        {
            StopDamage(); // 確保不會重複啟動

            damageSubscription = Observable.Interval(TimeSpan.FromSeconds(damageInterval))
                .Subscribe(_ =>
                {
                    damageProvider.StartDamage(); // 對玩家造成傷害
                });
        }

        // 停止傷害
        public void StopDamage()
        {
            damageSubscription?.Dispose();
            damageSubscription = null;
        }

        public void Dispose()
        {
            StopDamage();
        }
    }
}
