using Zenject;

namespace Modules.Scripts
{
    public interface IKeyboard
    {
        IKeyTracker TrackSelect { get; set; }
    }

    public class Keyboard : IKeyboard
    {
        [Inject]
        private IKeyTracker selectKeyTracker;
        public IKeyTracker TrackSelect
        {
            get => selectKeyTracker;
            set => selectKeyTracker = value;
        }
    }

    public interface IKeyTracker
    {
        void SetKeyPerforming(bool keyState);
        bool IsKeyPerforming();
        bool IsKeyPressed();
        int  GetKeyFrame();
    }

    public class InputTracker : IKeyTracker, ITickable
    {
        private bool isKeyPerforming;
        private bool isKeyPressed;
        private int  keyFrame;

        public void Tick()
        {
            isKeyPressed = isKeyPerforming && keyFrame == 0;
            keyFrame     = isKeyPerforming ? keyFrame + 1 : 0;
        }

        public void SetKeyPerforming(bool keyState) => isKeyPerforming = keyState;

        public int GetKeyFrame() => keyFrame;

        public bool IsKeyPerforming() => isKeyPerforming;
        public bool IsKeyPressed()    => isKeyPressed;
    }
}
