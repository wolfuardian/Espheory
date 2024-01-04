#region

using Eos.Gameplay.Player.Main;
using Eos.Gameplay.Player.Mono;
using Eos.Utils.System;
using Zenject;

#endregion

namespace Eos.Gameplay.Player.Handler
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