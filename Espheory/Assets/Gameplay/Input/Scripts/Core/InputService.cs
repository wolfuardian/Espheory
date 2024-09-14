#region

using Zenject;

#endregion

namespace Gameplay.Input.Core
{
    public interface IInputService
    {
        IInputTrack InputTrack { get; set; }
    }

    public class InputService : IInputService
    {
        #region Properties

        [Inject] public IInputTrack InputTrack { get; set; }

        #endregion
    }
}
