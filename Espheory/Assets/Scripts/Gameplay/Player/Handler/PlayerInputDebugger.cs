#region

using Zenject;
using Eos.UI.Effect;
using Eos.Gameplay.Player.Main;

#endregion

namespace Eos.Gameplay.Player.Handler
{
    public class PlayerInputDebugger : ITickable
    {
        #region Public Variables

        [Inject]                           private readonly InputState m_InputState;
        [Inject(Id = "D_LOOK_AROUND")]     public readonly  UIFader    lookAroundDebugger;
        [Inject(Id = "D_MOVE_FORWARD")]    public readonly  UIFader    moveForwardDebugger;
        [Inject(Id = "D_MOVE_HORIZONTAL")] public readonly  UIFader    moveHorizontalDebugger;
        [Inject(Id = "D_MOVE_VERTICAL")]   public readonly  UIFader    moveVerticalDebugger;
        [Inject(Id = "D_SELECT")]          public readonly  UIFader    selectDebugger;

        #endregion

        #region Public Methods

        public void Tick()
        {
            selectDebugger.TriggerFade(m_InputState.Select);
            lookAroundDebugger.TriggerFade(m_InputState.LookAround);
            moveForwardDebugger.TriggerFade(m_InputState.MoveForward);
            moveHorizontalDebugger.TriggerFade(m_InputState.MoveHorizontal);
            moveVerticalDebugger.TriggerFade(m_InputState.MoveVertical);
        }

        #endregion
    }
}