using Zenject;

namespace Modules.Scripts
{
    public interface IKeyTracker
    {
        void SetKeyDown(bool keyState);
        bool IsKeyPerforming();
        bool IsKeyPressed();
        bool IsKeyReleased();
        bool IsKeyCooldown();
        bool IsKeyIdle();
    }

    public class InputTracker : IKeyTracker, ITickable
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

        public bool IsKeyPerforming()
        {
            return isKeyDown;
        }

        public bool IsKeyPressed()
        {
            return isKeyPush;
        }

        public bool IsKeyReleased()
        {
            return !isKeyDown && keyDownFrame > 0;
        }

        public bool IsKeyCooldown()
        {
            return isKeyDown && keyDownFrame > 0;
        }

        public bool IsKeyIdle()
        {
            return !isKeyDown && keyDownFrame == 0;
        }
    }
}
