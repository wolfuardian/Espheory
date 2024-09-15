using Zenject;

namespace Gameplay.Player.Core
{
    public interface IActionState
    {
        IActionTrackPerformer TpSelect { get; }
    }

    public class ActionState : IActionState
    {
        [Inject] public IActionTrackPerformer TpSelect { get; }
    }
}
