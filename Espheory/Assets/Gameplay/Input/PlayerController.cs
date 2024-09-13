#region

using Gameplay.Navigate.Scripts;
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

        
        
        [Inject]
        private INavService navService;
        
        #endregion

        private bool ShouldSelect   => inputState.IsSelectPressed;
        private bool ShouldTarget   => inputState.IsTargetPressed;
        private bool ShouldNavigate => inputState.IsSelectPressed; // 之後改 actionState.IsNavigating

        #region Public Methods

        public void Tick()
        {
            DoSelect();
            DoTarget();
            DoNavigate();
        }

        #endregion

        #region Private Methods

        private void DoSelect()
        {
            if (ShouldSelect) actionService.Select();
        }

        private void DoTarget()
        {
            // if (ShouldTarget) m_NavService.Target();
        }

        private void DoNavigate()
        {
            if (ShouldNavigate) navService.SetIsNavigateNext();
        }

        #endregion
    }
}
