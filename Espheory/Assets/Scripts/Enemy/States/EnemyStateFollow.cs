using UnityEngine;

namespace Espheory
{
    public class EnemyStateFollow : IEnemyState
    {
        readonly PlayerFacade _player;
        readonly EnemyView _view;
        readonly IEnemyStateManager _manager;
        readonly EnemyCommonSettings _commonSettings;

        public EnemyStateFollow(
            PlayerFacade player,
            EnemyView view,
            IEnemyStateManager manager,
            EnemyCommonSettings commonSettings)
        {
            _player = player;
            _view = view;
            _manager = manager;
            _commonSettings = commonSettings;
        }

        public void EnterState()
        {
            _view.Alert();
        }

        public void ExitState()
        {
            _view.StopMove();
        }

        public void Update()
        {
            var distanceToPlayer = (_player.Position - _view.Position).magnitude;

            if (distanceToPlayer < _commonSettings.AlertDistance)
            {
                _manager.ChangeState(EnemyStates.Attack);
            }

            if (distanceToPlayer > _commonSettings.WarningDistance)
            {
                _manager.ChangeState(EnemyStates.Idle);
            }
        }

        public void FixedUpdate()
        {
            MoveTowardsPlayer();
        }

        void MoveTowardsPlayer()
        {
            var direction   = (_player.Position - _view.Position).normalized;
            var speed       = _commonSettings.FollowSpeed;
            var newPosition = _view.Position + direction * speed * Time.fixedDeltaTime;

            _view.Move(newPosition);
        }
    }
}
