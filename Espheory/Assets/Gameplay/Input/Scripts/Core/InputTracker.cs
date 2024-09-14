#region

using Zenject;

#endregion

namespace Gameplay.Input.Core
{
    public interface IInputTracker
    {
        void Started();
        void Performed();
        void Canceled();
        int  GetFrameCount();
    }

    public class InputTracker : IInputTracker, ITickable
    {
        #region Private Valiables

        private bool isPerforming;
        private int  frameCount;

        #endregion

        #region Public Methods

        public void Tick() => frameCount = isPerforming ? frameCount + 1 : -1;

        public void Started()   => frameCount = -1; // Force reset
        public void Performed() => isPerforming = true;
        public void Canceled()  => isPerforming = false;

        public int GetFrameCount() => frameCount;

        #endregion
    }
}
