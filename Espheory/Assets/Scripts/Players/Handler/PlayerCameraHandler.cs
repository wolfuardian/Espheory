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

        private readonly                                InputState _inputState;
        [Inject(Id = "MainCamera")]     public readonly Camera     MainCamera;
        [Inject(Id = "CameraPivot")]    public readonly Transform  CameraPivot;
        [Inject(Id = "CameraPitchYaw")] public readonly Transform  CameraPitchYaw;
        [Inject(Id = "CameraDolly")]    public readonly Transform  CameraDolly;

        #endregion

        #region Public Methods

        public PlayerCameraHandler(InputState inputState)
        {
            _inputState = inputState;
        }

        public void Tick()
        {
            if (!_inputState.IsLookAround) return;

            var eulerAngles = CameraPitchYaw.eulerAngles;
            eulerAngles = new Vector3(
                eulerAngles.x - _inputState.PitchDelta * 0.1f,
                eulerAngles.y + _inputState.YawDelta * 0.1f,
                eulerAngles.z
            );
            CameraPitchYaw.eulerAngles = eulerAngles;
        }

        #endregion
    }
}