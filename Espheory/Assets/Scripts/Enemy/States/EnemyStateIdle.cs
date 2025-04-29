namespace Espheory
{
    public class EnemyStateIdle : IEnemyState
    {
        readonly PlayerFacade _player;
        readonly EnemyView _view;
        readonly IEnemyStateManager _manager;
        readonly EnemyCommonSettings _commonSettings;

        public EnemyStateIdle(
            PlayerFacade player,
            EnemyView view,
            IEnemyStateManager manager,
            EnemyCommonSettings commonSettings
            )
        {
            _player = player;
            _view = view;
            _manager = manager;
            _commonSettings = commonSettings;
        }

        public void EnterState()
        {
            _view.Idle();
        }

        public void ExitState()
        {
        }

        public void Update()
        {
            var distanceToPlayer = (_player.Position - _view.Position).magnitude;

            if (distanceToPlayer < _commonSettings.WarningDistance)
            {
                _manager.ChangeState(EnemyStates.Follow);
            }
        }

        public void FixedUpdate()
        {
        }
    }
}
