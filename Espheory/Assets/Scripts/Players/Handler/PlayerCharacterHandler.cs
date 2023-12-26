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
            var eulerAngles = Player.eulerAngles;
            eulerAngles = new Vector3(
                eulerAngles.x,
                CameraPitchYaw.eulerAngles.y,
                eulerAngles.z
            );
            Player.eulerAngles = eulerAngles;

            var moveDirection = CameraPitchYaw.forward * _inputState.Vertical +
                                CameraPitchYaw.right * _inputState.Horizontal;
            PlayerController.position += new Vector3(
                moveDirection.x * 0.1f,
                0,
                moveDirection.z * 0.1f
            );
        }

        #endregion
    }
}