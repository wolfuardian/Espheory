namespace Eos.Players.Main
{
    public class PlayerInputState
    {
        #region Public Variables

        public float Pitch         { get; private set; }
        public float Yaw           { get; private set; }
        public int   LevelOfDolly  { get; private set; }
        public float Horizontal    { get; private set; }
        public float Vertical      { get; private set; }
        public bool  Dodge         { get; private set; }
        public bool  TurnAround    { get; private set; }
        public bool  LockOnTarget  { get; private set; }
        public int   IndexOfTarget { get; private set; }

        #endregion

        #region Public Methods

        public void SetPitch(float        pitch)         => Pitch = pitch;
        public void SetYaw(float          yaw)           => Yaw = yaw;
        public void SetHorizontal(float   horizontal)    => Horizontal = horizontal;
        public void SetVertical(float     vertical)      => Vertical = vertical;
        public void SetLevelOfDolly(int levelOfDolly)  => LevelOfDolly = levelOfDolly;
        public void SetDodge(bool         dodge)         => Dodge = dodge;
        public void SetTurnAround(bool    turnAround)    => TurnAround = turnAround;
        public void SetLockOnTarget(bool  lockOnTarget)  => LockOnTarget = lockOnTarget;
        public void SetIndexOfTarget(int  indexOfTarget) => IndexOfTarget = indexOfTarget;

        #endregion
    }
}