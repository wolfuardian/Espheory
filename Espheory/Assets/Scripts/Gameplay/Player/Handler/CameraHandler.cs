#region

using Eos.Gameplay.Context.Scene;
using Eos.Gameplay.Player.Main;
using Eos.Utils.System;
using Zenject;

#endregion

namespace Eos.Gameplay.Player.Handler
{
    public class CameraHandler : ITickable
    {
        #region Public Variables

        [Inject] private readonly InputState      _inputState;
        [Inject] private readonly ACameraPitchYaw _cameraPitchYaw;

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