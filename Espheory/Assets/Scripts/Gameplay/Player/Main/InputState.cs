using UnityEngine;

namespace Eos.Gameplay.Player.Main
{
    public class InputState
    {
        #region Public Variables

        public bool    LookAround     { get; private set; } // LOOK_AROUND
        public bool    MoveForward    { get; private set; } // MOVE_FORWARD
        public bool    MoveHorizontal { get; private set; } // MOVE_HORIZONTAL
        public bool    MoveVertical   { get; private set; } // MOVE_VERTICAL
        public float   Horizontal     { get; private set; }
        public float   Vertical       { get; private set; }
        public Vector2 MoveDirection  { get; private set; }
        public Vector2 MouseDelta     { get; private set; }
        public float   PitchDelta     { get; private set; }
        public float   YawDelta       { get; private set; }
        public int     LevelOfDolly   { get; private set; }

        // public float Horizontal          { get; private set; }
        // public float Vertical            { get; private set; }
        public bool Dodge         { get; private set; }
        public bool TurnAround    { get; private set; }
        public bool LockOnTarget  { get; private set; }
        public int  IndexOfTarget { get; private set; }

        #endregion

        #region Public Methods

        public void SetLookAround(bool       lookAround)     => LookAround = lookAround;
        public void SetMoveForward(bool      moveForward)    => MoveForward = moveForward;
        public void SetMoveHorizontal(bool   moveHorizontal) => MoveHorizontal = moveHorizontal;
        public void SetMoveVertical(bool     moveVertical)   => MoveVertical = moveVertical;
        public void SetHorizontal(float      horizontal)     => Horizontal = horizontal;
        public void SetVertical(float        vertical)       => Vertical = vertical;
        public void SetMoveDirection(Vector2 moveDirection)  => MoveDirection = moveDirection;
        public void SetMouseDelta(Vector2    mouseDelta)     => MouseDelta = mouseDelta;
        public void SetPitchDelta(float      pitchDelta)     => PitchDelta = pitchDelta;
        public void SetYawDelta(float        yawDelta)       => YawDelta = yawDelta;
        public void SetLevelOfDolly(int      levelOfDolly)   => LevelOfDolly = levelOfDolly;
        public void SetDodge(bool            dodge)          => Dodge = dodge;
        public void SetTurnAround(bool       turnAround)     => TurnAround = turnAround;
        public void SetLockOnTarget(bool     lockOnTarget)   => LockOnTarget = lockOnTarget;
        public void SetIndexOfTarget(int     indexOfTarget)  => IndexOfTarget = indexOfTarget;

        #endregion
    }
}