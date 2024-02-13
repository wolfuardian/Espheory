// #region
//
// using Zenject;
// using UnityEngine;
// using Eos.Utils.System;
// using Eos.Gameplay.Player.Main;
// using Eos.Gameplay.Context.Scene;
// using Eos.Gameplay.Input;
//
// #endregion
//
// namespace Eos.Gameplay.Player.Handler
// {
//     public class CharacterHandler : ITickable
//     {
//         private const string PLAYER_IDLE = "Player_Idle";
//         private const string PLAYER_WALK = "Player_Walk";
//         private const string PLAYER_RUN  = "Player_Run";
//         private const string PLAYER_ATTACK  = "Player_Attack";
//
//
//         #region Injected Variables
//
//         [Inject]                      private readonly InputState      m_InputState;
//         [Inject]                      private readonly APlayer         m_Player;
//         [Inject]                      private readonly ACharacter      m_Character;
//         [Inject]                      private readonly ACameraPitchYaw m_CameraPitchYaw;
//         [Inject(Id = "MOVE_SPEED")]   private readonly float           m_MoveSpeed;
//         [Inject(Id = "LAYER_GROUND")] private readonly string          m_GroundLayerName;
//
//         #endregion
//
//         public void Tick()
//         {
//             RotateCharacterTowardsCamera();
//             MoveCharacter();
//             AdjustCharacterPositionToGround();
//         }
//
//         private void RotateCharacterTowardsCamera()
//         {
//             var targetYRotation = m_CameraPitchYaw.transform.eulerAngles.y;
//             m_Character.transform.SetYRotation(targetYRotation);
//         }
//
//         private void MoveCharacter()
//         {
//             var direction = CalculateCharacterDirection();
//             m_Player.transform.MovePosition(direction, m_MoveSpeed);
//         }
//
//         private Vector3 CalculateCharacterDirection()
//         {
//             return (m_Character.transform.ForwardDirection(m_InputState.MoveDirection.y) +
//                     m_CameraPitchYaw.transform.RightDirection(m_InputState.MoveDirection.x)).normalized;
//         }
//
//         private void AdjustCharacterPositionToGround()
//         {
//             if (GroundRaycast(m_Player.transform.position, out var hit))
//             {
//                 m_Player.transform.SetYPosition(hit.point.y);
//             }
//         }
//
//         private bool GroundRaycast(Vector3 position, out RaycastHit hit)
//         {
//             var groundLayerMask = LayerMask.GetMask(m_GroundLayerName);
//             return Physics.Raycast(position, Vector3.up,   out hit, Mathf.Infinity, groundLayerMask) ||
//                    Physics.Raycast(position, Vector3.down, out hit, Mathf.Infinity, groundLayerMask);
//         }
//     }
// }