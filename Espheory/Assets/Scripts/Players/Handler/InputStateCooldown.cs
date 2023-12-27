#region

using Eos.Players.Main;
using UnityEngine;
using Zenject;

#endregion

namespace Eos.Players.Handler
{
    public class InputStateCooldown : ITickable
    {
        #region Public Variables

        [Inject] private readonly InputState _inputState;
        public                    float      CooldownDuration   = 30f;
        public                    Cooldown   LookAroundCooldown = new Cooldown(5f);

        #endregion

        #region Public Methods

        public void Tick()
        {
            _inputState.LookAround.Update();
            Debug.Log("LookAround.Cooldown = " + _inputState.LookAround.CooldownTimer);
        }

        #endregion
    }
}