using Zenject;

namespace Gameplay.Input.Core
{
    public interface IInputTrackPerformer
    {
        void Started();
        void Performed();
        void Canceled();
        int  GetFrameCount();
    }

    public class InputTrackPerformer : IInputTrackPerformer, ITickable
    {
        private bool isPerforming;
        private int  frameCount;

        public void Tick() => frameCount = isPerforming ? frameCount + 1 : 0;

        public void Started()   => frameCount = 0; // Force reset
        public void Performed() => isPerforming = true;
        public void Canceled()  => isPerforming = false;

        public int GetFrameCount() => frameCount;
    }
}
