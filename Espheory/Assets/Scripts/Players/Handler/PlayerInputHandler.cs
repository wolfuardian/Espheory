#region

using Eos.Players.Main;
using UnityEngine;
using Zenject;

#endregion

namespace Eos.Players.Handler
{
    public class PlayerInputHandler : ITickable
    {
        #region Public Variables

        [Inject] private PlayerInputState inputState;

        #endregion


        #region Public Methods

        public void Tick()
        {
            inputState.SetPitch(Input.GetAxis("Mouse Y"));
            inputState.SetYaw(Input.GetAxis("Mouse X"));
            inputState.SetDolly(Input.GetAxis("Mouse ScrollWheel"));
            inputState.SetHorizontal(Input.mouseScrollDelta.x);
            inputState.SetVertical(Input.mouseScrollDelta.y);
        }

        #endregion
    }
}