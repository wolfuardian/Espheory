#region

using Eos.Players.Main;
using UnityEngine;
using Zenject;

#endregion

namespace Eos.Players.Handler
{
    public class PlayerCharacterHandler : ITickable
    {
        #region Public Variables

        [Inject]                          private readonly InputState _inputState;
        [Inject(Id = "Player")]           public readonly  Transform  Player;
        [Inject(Id = "PlayerController")] public readonly  Transform  PlayerController;
        [Inject(Id = "CameraPitchYaw")]   public readonly  Transform  CameraPitchYaw;
        [Inject(Id = "MoveSpeed")]        public           float      MoveSpeed { get; }

        #endregion

        #region Public Methods

        public void Tick()
        {
            HRotatePlayerByCamera();
            MovePlayer();
        }

        #endregion

        #region Private Methods

        private void HRotatePlayerByCamera()
        {
            var eulerAngles = Player.eulerAngles;
            eulerAngles = new Vector3(
                eulerAngles.x,
                CameraPitchYaw.eulerAngles.y,
                eulerAngles.z
            );
            Player.eulerAngles = eulerAngles;
        }

        private void MovePlayer()
        {
            var moveDirection = CameraPitchYaw.forward * _inputState.MoveDirection.y +
                                CameraPitchYaw.right * _inputState.MoveDirection.x;
            var moveDelta = moveDirection.normalized;
            PlayerController.position += new Vector3(
                moveDelta.x * MoveSpeed,
                0,
                moveDelta.z * MoveSpeed
            );
        }

        #endregion
    }
}