using UnityEngine;

namespace Eos.Players.Main
{
    public class InputState
    {
        #region Public Variables

        public bool  LookAround    { get; private set; }
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

        public void SetLookAround(bool   lookAround)    => LookAround = lookAround;
        public void SetPitchDelta(float  pitchDelta)    => PitchDelta = pitchDelta;
        public void SetYawDelta(float    yawDelta)      => YawDelta = yawDelta;
        public void SetHorizontal(float  horizontal)    => Horizontal = horizontal;
        public void SetVertical(float    vertical)      => Vertical = vertical;
        public void SetLevelOfDolly(int  levelOfDolly)  => LevelOfDolly = levelOfDolly;
        public void SetDodge(bool        dodge)         => Dodge = dodge;
        public void SetTurnAround(bool   turnAround)    => TurnAround = turnAround;
        public void SetLockOnTarget(bool lockOnTarget)  => LockOnTarget = lockOnTarget;
        public void SetIndexOfTarget(int indexOfTarget) => IndexOfTarget = indexOfTarget;

        #endregion
    }
}