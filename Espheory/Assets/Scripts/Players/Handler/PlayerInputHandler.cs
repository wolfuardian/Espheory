#region

using UnityEngine;
using Zenject;

#endregion

namespace Eos.Players.Handler
{
    public class PlayerInputHandler : ITickable
    {
        #region Public Variables

        [Inject] private CameraInputState inputState;

        #endregion


        #region Public Methods

        public void Tick()
        {
            inputState.SetHorizontal(Input.mouseScrollDelta.x);
            inputState.SetVertical(Input.mouseScrollDelta.y);
        }

        #endregion


    }
}