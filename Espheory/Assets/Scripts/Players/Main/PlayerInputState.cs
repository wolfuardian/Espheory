#region

using UnityEngine;

#endregion

namespace Eos.Players.Main
{
    public class PlayerInputState
    {
        #region Public Variables

        public float Pitch      { get; private set; }
        public float Yaw        { get; private set; }
        public float Dolly      { get; private set; }
        public float Horizontal { get; private set; }
        public float Vertical   { get; private set; }
        public bool  Dodge      { get; private set; }
        public bool  TurnAround { get; private set; }
        public bool  LockOn     { get; private set; }

        #endregion

        #region Public Methods

        public void SetHorizontal(float horizontal)
        {
            Horizontal = horizontal;
        }

        public void SetVertical(float vertical)
        {
            Vertical = vertical;
        }

        #endregion
    }
}