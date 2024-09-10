#region

using Zenject;

#endregion

namespace Espheory.Player
{
    public class PlayerController : ITickable
    {
        #region Private Variables

        [Inject] private IActionService actionService;
        [Inject] private IInputReader   inputReader;

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
            var isSelectKeyPush = inputReader.IsSelectKeyStarted();
            if (isSelectKeyPush) actionService.Select();
        }

        #endregion
    }
}