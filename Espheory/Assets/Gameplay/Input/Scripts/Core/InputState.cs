namespace Gameplay.Input.Core
{
    public interface IInputState
    {
        int PerformingSelect { get; set; }
    }

    public class InputState : IInputState
    {
        #region Properties

        public int PerformingSelect { get; set; }

        #endregion
    }
}
