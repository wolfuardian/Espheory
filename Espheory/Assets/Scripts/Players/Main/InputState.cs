namespace Eos.Players.Main
{
    public class InputState
    {
        #region Public Variables

        public bool  IsLookaround  { get; private set; }
        public float PitchDelta    { get; private set; }
        public float YawDelta      { get; private set; }
        public int   LevelOfDolly  { get; private set; }
        public float Horizontal    { get; private set; }
        public float Vertical      { get; private set; }
        public bool  Dodge         { get; private set; }
        public bool  TurnAround    { get; private set; }
        public bool  LockOnTarget  { get; private set; }
        public int   IndexOfTarget { get; private set; }

        #endregion

        #region Public Methods

        public void SetLookaround(bool   val) => IsLookaround = val;
        public void SetPitchDelta(float  val) => PitchDelta = val;
        public void SetYawDelta(float    val) => YawDelta = val;
        public void SetHorizontal(float  val) => Horizontal = val;
        public void SetVertical(float    val) => Vertical = val;
        public void SetLevelOfDolly(int  val) => LevelOfDolly = val;
        public void SetDodge(bool        val) => Dodge = val;
        public void SetTurnAround(bool   val) => TurnAround = val;
        public void SetLockOnTarget(bool val) => LockOnTarget = val;
        public void SetIndexOfTarget(int val) => IndexOfTarget = val;

        #endregion
    }
}