using System.Collections.Generic;
using ModestTree;
using Zenject;

namespace Espheory
{
    public interface IEnemyState
    {
        void ExitState();
        void EnterState();
        void Update();
        void FixedUpdate();
    }

    public enum EnemyStates
    {
        Idle,
        Follow,
        Attack,
        None
    }

    public interface IEnemyStateManager
    {
        void ChangeState(EnemyStates state);
    }

    public class EnemyStateManager : ITickable, IFixedTickable, IInitializable, IEnemyStateManager
    {
        IEnemyState _currentStateHandler;
        EnemyStates _currentState = EnemyStates.None;

        List<IEnemyState> _states;

        [Inject]
        public void Construct(EnemyStateIdle idle, EnemyStateAttack attack, EnemyStateFollow follow)
        {
            _states = new List<IEnemyState>
            {
                // This needs to follow the enum order
                idle, follow, attack
            };
        }

        public void Initialize()
        {
            Assert.IsEqual(_currentState, EnemyStates.None);
            Assert.IsNull(_currentStateHandler);

            ChangeState(EnemyStates.Idle);
        }

        public void ChangeState(EnemyStates state)
        {
            if (_currentState == state)
            {
                return;
            }

            _currentState = state;

            if (_currentStateHandler != null)
            {
                _currentStateHandler.ExitState();
                _currentStateHandler = null;
            }

            _currentStateHandler = _states[(int)state];
            _currentStateHandler.EnterState();
        }

        public void Tick()
        {
            _currentStateHandler.Update();
        }

        public void FixedTick()
        {
            _currentStateHandler.FixedUpdate();
        }
    }
}
