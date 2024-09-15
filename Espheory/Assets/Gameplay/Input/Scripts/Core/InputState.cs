namespace Gameplay.Input.Core
{
    public interface IInputState
    {
        int PerformingSelect { get; set; }
    }

    public class InputState : IInputState
    {
        public int PerformingSelect { get; set; }
    }
}
