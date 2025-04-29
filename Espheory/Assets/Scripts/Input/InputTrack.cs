using Zenject;

namespace Gameplay.Input.Core
{
    public interface IInputTrack
    {
        IInputTrackPerformer TpSelect { get; set; }
    }

    public class InputTrack : IInputTrack, ITickable
    {
        [Inject] private IInputState inputState;

        [Inject] public IInputTrackPerformer TpSelect { get; set; }

        public void Tick()
        {
            inputState.PerformingSelect = TpSelect.GetFrameCount();
        }
    }
}
