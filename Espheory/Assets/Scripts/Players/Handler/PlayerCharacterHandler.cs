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

        #endregion

        #region Public Methods

        public void Tick()
        {
            UpdatePlayerRotation();
            UpdatePlayerPosition();
        }

        #endregion

        #region Private Methods

        private void UpdatePlayerRotation()
        {
            var eulerAngles = Player.eulerAngles;
            eulerAngles = new Vector3(
                eulerAngles.x,
                CameraPitchYaw.eulerAngles.y,
                eulerAngles.z
            );
            Player.eulerAngles = eulerAngles;
        }

        private void UpdatePlayerPosition()
        {
            var moveDirection = CameraPitchYaw.forward * _inputState.MoveDirection.y +
                                CameraPitchYaw.right * _inputState.MoveDirection.x;
            PlayerController.position += new Vector3(
                moveDirection.x * 0.1f,
                0,
                moveDirection.z * 0.1f
            );
        }

        #endregion
    }
}