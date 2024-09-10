using Zenject;

namespace Espheory.Player
{
    public interface IInputKey
    {
        #region Public Variables

        bool IsKeyStarted();
        bool IsKeyPerformed();
        bool IsKeyCanceled();

        #endregion

        #region Public Methods

        void SetKeyPerformed();
        void SetKeyCanceled();

        #endregion
    }

    public class InputKeyTracker : IInputKey, ITickable
    {
        #region Private Variables

        private bool isKeyStarted;
        private bool isKeyPerformed;
        private bool isKeyCanceled;

        private int keyFrame;

        #endregion

        #region Public Methods

        public void Tick()
        {
            isKeyStarted  = isKeyPerformed && keyFrame == 0;
            isKeyCanceled = !isKeyPerformed && keyFrame > 0;

            keyFrame = isKeyPerformed ? keyFrame + 1 : 0;
        }
        public void SetKeyPerformed()
        {
            isKeyPerformed = true;
        }

        public void SetKeyCanceled()
        {
            isKeyPerformed = false;
        }

        public bool IsKeyStarted()
        {
            return isKeyStarted;
        }

        public bool IsKeyPerformed()
        {
            return isKeyPerformed;
        }

        public bool IsKeyCanceled()
        {
            return isKeyCanceled;
        }

        #endregion
    }
}