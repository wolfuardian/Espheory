// #region
//
// using Zenject;
// using Eos.Utils.System;
// using Eos.Gameplay.Player.Main;
// using Eos.Gameplay.Context.Scene;
// using Eos.Gameplay.Input;
//
// #endregion
//
// namespace Eos.Gameplay.Player.Handler
// {
//     public class CameraHandler : ITickable
//     {
//         #region Public Variables
//
//         [Inject] private readonly InputState      m_InputState;
//         [Inject] private readonly ACameraPitchYaw m_CameraPitchYaw;
//
//         #endregion
//
//         #region Public Methods
//
//         public void Tick()
//         {
//             AdjustCameraYaw();
//         }
//
//         private void AdjustCameraYaw()
//         {
//             if (!m_InputState.LookAround) return;
//
//             m_CameraPitchYaw.transform.AdjustYaw(m_InputState.YawDelta);
//         }
//
//         #endregion
//     }
// }