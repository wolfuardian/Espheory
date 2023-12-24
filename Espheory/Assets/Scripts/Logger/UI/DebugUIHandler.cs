#region

using Eos.Players.Main;
using Zenject;

#endregion

namespace Eos.Logger.UI
{
    public class DebugUIHandler : ITickable
    {
        #region Public Variables

        [Inject]                       private PlayerInputState inputState;
        [Inject(Id = "PitchDelta")]    private UITextLogger     loggerPitch;
        [Inject(Id = "YawDelta")]      private UITextLogger     loggerYaw;
        [Inject(Id = "LevelOfDolly")]  private UITextLogger     loggerLevelOfDolly;
        [Inject(Id = "Horizontal")]    private UITextLogger     loggerHorizontal;
        [Inject(Id = "Vertical")]      private UITextLogger     loggerVertical;
        [Inject(Id = "Dodge")]         private UITextLogger     loggerDodge;
        [Inject(Id = "TurnAround")]    private UITextLogger     loggerTurnAround;
        [Inject(Id = "LockOnTarget")]  private UITextLogger     loggerLockOnTarget;
        [Inject(Id = "IndexOfTarget")] private UITextLogger     loggerIndexOfTarget;

        #endregion

        #region Public Methods

        public void Tick()
        {
            loggerPitch.SetDisplayText("Pitch: " + inputState.Pitch);
            loggerYaw.SetDisplayText("Yaw: " + inputState.Yaw);
            loggerLevelOfDolly.SetDisplayText("LevelOfDolly: " + inputState.LevelOfDolly);
            loggerHorizontal.SetDisplayText("Horizontal: " + inputState.Horizontal);
            loggerVertical.SetDisplayText("Vertical: " + inputState.Vertical);
            loggerDodge.SetDisplayText("Dodge: " + inputState.Dodge);
            loggerTurnAround.SetDisplayText("TurnAround: " + inputState.TurnAround);
            loggerLockOnTarget.SetDisplayText("TurnAround: " + inputState.LockOnTarget);
            loggerIndexOfTarget.SetDisplayText("IndexOfTarget: " + inputState.IndexOfTarget);
        }

        #endregion
    }
}