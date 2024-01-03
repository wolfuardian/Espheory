#region

using UnityEngine;
using Zenject;
using Eos.Gameplay.Players.Main;

#endregion

namespace Eos.Gameplay.Players.Handler
{
    public class CharacterHandler : ITickable
    {
        #region Public Variables

        [Inject]                        private readonly InputState inputState;
        [Inject(Id = "Player")]         public readonly  Transform  Player;
        [Inject(Id = "Character")]      public readonly  Transform  Character;
        [Inject(Id = "CameraPitchYaw")] public readonly  Transform  CameraPitchYaw;
        [Inject(Id = "MoveSpeed")]      public           float      MoveSpeed { get; }

        #endregion

        #region Public Methods

        public void Tick()
        {
            AlignCharacterWithCamera();
            MovePlayer();
        }

        #endregion

        #region Private Methods

        private Vector3 CharacterDirection
        {
            get
            {
                var characterDirection = CameraPitchYaw.forward * inputState.MoveDirection.y +
                                         CameraPitchYaw.right * inputState.MoveDirection.x;
                return characterDirection.normalized;
            }
        }

        private void AlignCharacterWithCamera()
        {
            var eulerAngles = Character.eulerAngles;
            eulerAngles = new Vector3(
                eulerAngles.x,
                CameraPitchYaw.eulerAngles.y,
                eulerAngles.z
            );
            Character.eulerAngles = eulerAngles;
        }

        private void MovePlayer()
        {
            Player.position += new Vector3(
                CharacterDirection.x * MoveSpeed,
                0,
                CharacterDirection.z * MoveSpeed
            );
        }

        #endregion
    }
}