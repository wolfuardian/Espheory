using Zenject;

namespace Espheory
{
    public interface IEnemyDeathHandler
    {
        void Die();
    }

    public class EnemyDeathHandler : IEnemyDeathHandler
    {
        readonly EnemyFacade _enemyFacade;
        readonly SignalBus _signalBus;

        public EnemyDeathHandler(EnemyFacade enemyFacade, SignalBus signalBus)
        {
            _enemyFacade = enemyFacade;
            _signalBus = signalBus;
        }

        public void Die()
        {
            _signalBus.Fire<EnemyKilledSignal>();

            _enemyFacade.Dispose();
        }
    }
}
