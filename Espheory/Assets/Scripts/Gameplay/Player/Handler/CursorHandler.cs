#region

using Eos.Gameplay.Player.Main;
using Zenject;

#endregion

namespace Eos.Gameplay.Player.Handler
{
    public class CursorHandler : ITickable
    {
        #region Public Variables

        [Inject] private readonly InputState _inputState;

        #endregion

        #region Public Methods

        public void Tick()
        {
        }

        #endregion
    }
}