#region

using Zenject;

#endregion

namespace Gameplay.Input.Core
{
    public interface IInputRecorder
    {
        IInputTracker TrackingSelect { get; set; }
    }

    public class InputRecorder : IInputRecorder, ITickable
    {
        #region Private Valiables

        [Inject]
        private IInputState inputState;

        #endregion

        #region Properties

        [Inject] public IInputTracker TrackingSelect { get; set; }

        #endregion

        #region Public Methods

        public void Tick()
        {
            inputState.PerformingSelect = TrackingSelect.GetFrameCount();
        }

        #endregion
    }
}
