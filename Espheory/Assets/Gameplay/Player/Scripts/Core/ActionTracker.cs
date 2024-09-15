using Zenject;

namespace Gameplay.Player.Core
{
    public interface IActionTracker
    {
        IActionTrackPerformer TpSelect { get; }
    }

    public class ActionTracker : IActionTracker
    {
        [Inject] public IActionTrackPerformer TpSelect { get; }
    }
}
