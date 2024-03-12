using Zenject;

namespace Espheory.Player
{
    public interface IActionService
    {
        #region Public Methods

        void Select();

        #endregion
    }

    public class ActionService : IActionService
    {
        #region Public Variables

        public readonly int selectValue = 1;

        #endregion

        #region Private Variables

        [Inject] private IAction action;

        #endregion

        #region Public Methods

        public void Select()
        {
            var isStateNotIdle = IsNotState(ActionState.Idle);
            if (isStateNotIdle)
            {
                return;
            }

            action.Select(selectValue);
        }

        #endregion

        #region Private Methods

        private bool IsNotState(ActionState state)
        {
            return action.State != state;
        }

        #endregion
    }
}