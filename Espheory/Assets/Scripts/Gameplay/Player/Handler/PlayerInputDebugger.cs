#region

using Eos.Gameplay.Player.Main;
using Eos.UI.Effect;
using UnityEngine.UI;
using Zenject;

#endregion

namespace Eos.Gameplay.Player.Handler
{
    public class PlayerInputDebugger : ITickable
    {
        #region Public Variables

        [Inject]                           private readonly InputState _inputState;
        [Inject(Id = "D_LOOK_AROUND")]     public readonly  UIFader    LookAroundDebugger;
        [Inject(Id = "D_MOVE_FORWARD")]    public readonly  UIFader    MoveForwardDebugger;
        [Inject(Id = "D_MOVE_HORIZONTAL")] public readonly  UIFader    MoveHorizontalDebugger;
        [Inject(Id = "D_MOVE_VERTICAL")]   public readonly  UIFader    MoveVerticalDebugger;
        [Inject(Id = "D_SELECT")]          public readonly  UIFader    SelectDebugger;

        #endregion

        #region Public Methods

        public void Tick()
        {
            SelectDebugger.TriggerFade(_inputState.Select);
            LookAroundDebugger.TriggerFade(_inputState.LookAround);
            MoveForwardDebugger.TriggerFade(_inputState.MoveForward);
            MoveHorizontalDebugger.TriggerFade(_inputState.MoveHorizontal);
            MoveVerticalDebugger.TriggerFade(_inputState.MoveVertical);
        }

        #endregion
    }
}