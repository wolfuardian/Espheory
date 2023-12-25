#region

using Eos.Players.Main;
using UnityEngine;
using Zenject;

#endregion

namespace Eos.Players.Handler
{
    public class PlayerCameraHandler : ITickable
    {
        #region Public Variables

        private readonly InputState _inputState;

        #endregion

        #region Public Methods

        public PlayerCameraHandler(InputState inputState)
        {
            _inputState = inputState;
        }

        public void Tick()
        {
            if (_inputState.IsLookaround)
            {
                Debug.Log("Mouse X: " + _inputState.YawDelta + " Mouse Y: " + _inputState.PitchDelta);
                // TODO: Rotate camera
            }
        }

        #endregion
    }
}