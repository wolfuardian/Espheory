#region

using Zenject;

#endregion

namespace Gameplay.Input.Core
{
    public interface IInputTrack
    {
        IInputTrackPerformer TpSelect { get; set; }
    }

    public class InputTrack : IInputTrack, ITickable
    {
        #region Private Valiables

        [Inject]
        private IInputState inputState;

        #endregion

        #region Properties

        [Inject] public IInputTrackPerformer TpSelect { get; set; }

        #endregion

        #region Public Methods

        public void Tick()
        {
            inputState.PerformingSelect = TpSelect.GetFrameCount();
        }

        #endregion
    }
}
