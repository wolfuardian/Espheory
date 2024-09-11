#region

using Zenject;

#endregion

namespace Gameplay.Input
{
    public class PlayerController : ITickable
    {
        #region Private Variables

        [Inject]
        private IActionService actionService;
        [Inject]
        private IInputReader inputReader;
        [Inject]
        private IInputState inputState;

        #endregion

        #region Public Methods

        public void Tick()
        {
            DoSelect();
        }

        #endregion

        #region Private Methods

        private void DoSelect()
        {
            if (inputState.IsSelectPressed) actionService.Select();
        }

        #endregion
    }
}
