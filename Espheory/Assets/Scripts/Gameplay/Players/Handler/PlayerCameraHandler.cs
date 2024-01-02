#region

using Eos.Gameplay.Players.Main;
using UnityEngine;
using Zenject;

#endregion

namespace Eos.Gameplay.Players.Handler
{
    public class PlayerCameraHandler : ITickable
    {
        #region Public Variables

        [Inject]                        private readonly InputState _inputState;
        [Inject(Id = "MainCamera")]     public readonly  Camera     MainCamera;
        [Inject(Id = "CameraPivot")]    public readonly  Transform  CameraPivot;
        [Inject(Id = "CameraPitchYaw")] public readonly  Transform  CameraPitchYaw;
        [Inject(Id = "CameraDolly")]    public readonly  Transform  CameraDolly;

        #endregion

        #region Public Methods

        public void Tick()
        {
            if (!_inputState.LookAround) return;

            var eulerAngles = CameraPitchYaw.eulerAngles;
            eulerAngles = new Vector3(
                eulerAngles.x,
                eulerAngles.y + _inputState.YawDelta * 0.1f,
                eulerAngles.z
            );
            CameraPitchYaw.eulerAngles = eulerAngles;
        }

        #endregion
    }
}