using Zenject;
using Gameplay.Input.Core;

namespace Gameplay.Player.Core
{
    public class PlayerController : ITickable
    {
        [Inject] private IInputState    inputState;
        [Inject] private IActionTracker actionTracker;

        private bool ShouldSelect => inputState.PerformingSelect == 1;

        public void Tick()
        {
            DoSelect();
        }

        private void DoSelect()
        {
            if (ShouldSelect) actionTracker.TpSelect.Perform();
        }
    }




}
