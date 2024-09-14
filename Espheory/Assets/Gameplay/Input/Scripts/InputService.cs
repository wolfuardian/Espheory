namespace Gameplay.Input.Scripts
{
    public interface IInputService
    {
        IInputFsm Select { get; set; }
    }

    public class InputService : IInputService
    {
        public IInputFsm Select { get; set; }
    }
}
