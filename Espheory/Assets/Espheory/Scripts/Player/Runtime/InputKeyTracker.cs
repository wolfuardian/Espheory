using Zenject;

namespace Espheory.Player
{
    public interface IKeyTracker
    {
        void SetKeyDown(bool keyState);
        bool IsKeyDown();
        bool IsKeyPush();
    }

    public class InputKeyTracker : IKeyTracker, ITickable
    {
        private bool isKeyDown;
        private bool isKeyPush;
        private int  keyDownFrame;

        public void Tick()
        {
            isKeyPush    = isKeyDown && keyDownFrame == 0;
            keyDownFrame = isKeyDown ? keyDownFrame + 1 : 0;
        }

        public void SetKeyDown(bool keyState)
        {
            isKeyDown = keyState;
        }

        public bool IsKeyDown()
        {
            return isKeyDown;
        }

        public bool IsKeyPush()
        {
            return isKeyPush;
        }
    }
}