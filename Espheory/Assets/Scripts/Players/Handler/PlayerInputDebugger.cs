#region

using Eos.Players.Main;
using UnityEngine.UI;
using Zenject;

#endregion

namespace Eos.Players.Handler
{
    public class PlayerInputDebugger : ITickable
    {
        #region Public Variables

        [Inject]                           private readonly InputState _inputState;
        [Inject(Id = "D_LOOK_AROUND")]     public readonly  Toggle     LookAroundDebugger;
        [Inject(Id = "D_MOVE_FORWARD")]    public readonly  Toggle     MoveForwardDebugger;
        [Inject(Id = "D_MOVE_HORIZONTAL")] public readonly  Toggle     MoveHorizontalDebugger;
        [Inject(Id = "D_MOVE_VERTICAL")]   public readonly  Toggle     MoveVerticalDebugger;

        #endregion

        #region Public Methods

        public void Tick()
        {
            LookAroundDebugger.isOn     = _inputState.LookAround;
            MoveForwardDebugger.isOn    = _inputState.MoveForward;
            MoveHorizontalDebugger.isOn = _inputState.MoveHorizontal;
            MoveVerticalDebugger.isOn   = _inputState.MoveVertical;
        }

        #endregion
    }
}