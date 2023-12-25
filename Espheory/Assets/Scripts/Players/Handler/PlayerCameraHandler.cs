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

        public PlayerCameraHandler(InputState inputState)
        {
            _inputState = inputState;
        }

        #endregion

        #region Public Methods

        public void Tick()
        {
            Debug.Log(_inputState.IsLookaround);
        }

        #endregion
    }
}