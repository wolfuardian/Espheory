#region

using Eos.Players.Main;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

#endregion

namespace Eos.Players.Handler
{
    public class PlayerInputDebugger : ITickable
    {
        #region Public Variables

        [Inject]                          private readonly InputState _inputState;
        [Inject(Id = "DEBUG_LookAround")] public readonly  Toggle     DEBUG_LookAround;

        #endregion

        #region Public Methods

        public void Tick()
        {
            DEBUG_LookAround.isOn = _inputState.LookAround;
        }

        #endregion
    }
}