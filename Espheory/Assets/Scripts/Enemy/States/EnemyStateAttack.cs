namespace Espheory
{
    public class EnemyStateAttack : IEnemyState
    {
        readonly PlayerFacade _player;
        readonly EnemyView _view;
        readonly IEnemyStateManager _manager;
        readonly EnemyCommonSettings _commonSettings;

        public EnemyStateAttack(
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
            _view.Attack();
        }

        public void ExitState()
        {
        }

        public void Update()
        {
            var distanceToPlayer = (_player.Position - _view.Position).magnitude;

            if (distanceToPlayer > _commonSettings.AlertDistance)
            {
                _manager.ChangeState(EnemyStates.Follow);
            }

            if (distanceToPlayer > _commonSettings.WarningDistance)
            {
                _manager.ChangeState(EnemyStates.Idle);
            }
        }

        public void FixedUpdate()
        {
        }
    }
}
