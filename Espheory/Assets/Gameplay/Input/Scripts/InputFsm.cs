using Zenject;

namespace Gameplay.Input.Scripts
{
    public interface IInputFsm
    {
        void Initiate();
        void Perform();
        void Reset();
    }

    public class InputFsm : IInputFsm
    {
        private bool isPerforming;
        private bool isPressed;
        private int  frame;

        [Inject]
        private IInputPerformer inputPerformer;

        public void Initiate() => inputPerformer.Start();

        public void Perform()
        {
            UnityEngine.Debug.Log("Performing");
        }

        public void Reset() => inputPerformer.Reset();
    }

    public interface IInputPerformer
    {
        void Start();
        void Reset();
    }

    public class InputPerformer : IInputPerformer, ITickable
    {
        private bool isPerforming;
        private int  frame;

        public void Start() => isPerforming = true;
        public void Reset() => isPerforming = false;

        public void Tick()
        {
            frame = isPerforming ? frame + 1 : 0;
        }
    }
}
