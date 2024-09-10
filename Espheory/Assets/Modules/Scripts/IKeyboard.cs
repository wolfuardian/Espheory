using Zenject;

namespace Modules.Scripts
{
    public interface IKeyboard
    {
        IKeyTracker TrackSelect { get; set; }
    }

    public class Keyboard : IKeyboard
    {
        [Inject]
        private IKeyTracker selectKeyTracker;
        public IKeyTracker TrackSelect
        {
            get => selectKeyTracker;
            set => selectKeyTracker = value;
        }
    }
}
