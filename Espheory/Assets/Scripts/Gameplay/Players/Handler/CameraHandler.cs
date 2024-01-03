#region

using Zenject;
using Eos.Gameplay.Players.Main;
using Eos.Gameplay.Players.Mono;
using Eos.Utils.System;

#endregion

namespace Eos.Gameplay.Players.Handler
{
    public class CameraHandler : ITickable
    {
        #region Public Variables

        [Inject] private readonly InputState      _inputState;
        [Inject] private readonly MCameraPitchYaw _cameraPitchYaw;

        #endregion

        #region Public Methods

        public void Tick()
        {
            AdjustCameraYaw();
        }

        private void AdjustCameraYaw()
        {
            if (!_inputState.LookAround) return;

            _cameraPitchYaw.transform.AdjustYaw(_inputState.YawDelta);
        }

        #endregion
    }
}