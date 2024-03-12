#region

using Zenject;

#endregion

namespace Espheory.Player
{
    public interface IAction
    {
        #region Public Variables

        ActionState State { get; }

        #endregion

        #region Public Methods

        void Select(int value);

        #endregion
    }

    public enum ActionState
    {
        Idle,
        Select
    }

    public class ActionController : IAction, ITickable
    {
        #region Public Variables

        public readonly int defaultSelectFrame = 60;

        public ActionState State { get; private set; }

        #endregion

        #region Private Variables

        private int selectFrame;

        #endregion

        #region Public Methods

        public void Select(int value)
        {
            selectFrame = defaultSelectFrame;
            State       = ActionState.Select;
        }

        public void Tick()
        {
            Tick_Select();
        }

        #endregion

        #region Private Methods

        private void Tick_Select()
        {
            if (State == ActionState.Select)
            {
                selectFrame -= 1;
                if (selectFrame == 0) State = ActionState.Idle;
            }
        }

        #endregion
    }
}