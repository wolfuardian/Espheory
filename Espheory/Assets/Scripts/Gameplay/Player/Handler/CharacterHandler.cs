#region

using Eos.Gameplay.Player.Main;
using Eos.Gameplay.Player.Mono;
using Eos.Utils.System;
using UnityEngine;
using Zenject;

#endregion

namespace Eos.Gameplay.Player.Handler
{
    public class CharacterHandler : ITickable
    {
        #region Injected Variables

        [Inject]                      private readonly InputState      _inputState;
        [Inject]                      private readonly MPlayer         _player;
        [Inject]                      private readonly MCharacter      _character;
        [Inject]                      private readonly MCameraPitchYaw _cameraPitchYaw;
        [Inject(Id = "MOVE_SPEED")]   private readonly float           _moveSpeed;
        [Inject(Id = "LAYER_GROUND")] private readonly string          _groundLayerName;

        #endregion

        public void Tick()
        {
            RotateCharacterTowardsCamera();
            MoveCharacter();
            AdjustCharacterPositionToGround();
        }

        private void RotateCharacterTowardsCamera()
        {
            var targetYRotation = _cameraPitchYaw.transform.eulerAngles.y;
            _character.transform.SetYRotation(targetYRotation);
        }

        private void MoveCharacter()
        {
            var direction = CalculateCharacterDirection();
            _player.transform.MovePosition(direction, _moveSpeed);
        }

        private Vector3 CalculateCharacterDirection()
        {
            return (_character.transform.ForwardDirection(_inputState.MoveDirection.y) +
                    _cameraPitchYaw.transform.RightDirection(_inputState.MoveDirection.x)).normalized;
        }

        private void AdjustCharacterPositionToGround()
        {
            if (GroundRaycast(_player.transform.position, out var hit))
            {
                _player.transform.SetYPosition(hit.point.y);
            }
        }

        private bool GroundRaycast(Vector3 position, out RaycastHit hit)
        {
            var groundLayerMask = LayerMask.GetMask(_groundLayerName);
            return Physics.Raycast(position, Vector3.up,   out hit, Mathf.Infinity, groundLayerMask) ||
                   Physics.Raycast(position, Vector3.down, out hit, Mathf.Infinity, groundLayerMask);
        }
    }
}