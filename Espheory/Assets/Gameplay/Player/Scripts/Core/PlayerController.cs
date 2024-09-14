#region

using Zenject;
using UnityEngine;
using Gameplay.Input.Core;

#endregion

namespace Gameplay.Player.Core
{
    public class PlayerController : ITickable
    {
        #region Private Variables

        [Inject]
        private IInputState inputState;

        // [Inject]
        // IActionService actionService;

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
            // if (inputState.IsSelectPressed) actionService.Select();
            if (inputState.PerformingSelect == 0) Debug.Log("Player Selecting");
        }

        #endregion
    }
}
