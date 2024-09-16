using Zenject;

namespace Gameplay.Input.Core
{
    public interface IInputService
    {
        IInputTrack InputTrack { get; set; }
    }

    public class InputService : IInputService
    {
        [Inject] public IInputTrack InputTrack { get; set; }
    }
}
