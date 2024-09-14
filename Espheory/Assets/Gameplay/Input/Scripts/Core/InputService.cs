#region

using Zenject;

#endregion

namespace Gameplay.Input.Core
{
    public interface IInputService
    {
        IInputRecorder InputRecorder { get; set; }
    }

    public class InputService : IInputService
    {
        #region Properties

        [Inject] public IInputRecorder InputRecorder { get; set; }

        #endregion
    }
}
