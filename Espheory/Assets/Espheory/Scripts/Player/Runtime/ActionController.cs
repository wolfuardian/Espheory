#region

using UnityEngine;
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
        Select,
        SelectCooldown
    }

    public class ActionController : IAction, ITickable
    {
        #region Public Variables

        public readonly int defaultSelectActiveFrame   = 1;
        public readonly int defaultSelectCooldownFrame = 60;

        public ActionState State { get; private set; }

        #endregion

        #region Private Variables

        private int selectActiveFrame;
        private int selectCooldownFrame;

        #endregion

        #region Public Methods

        public void Select(int value)
        {
            selectActiveFrame   = defaultSelectActiveFrame;
            selectCooldownFrame = defaultSelectCooldownFrame;
            State               = ActionState.Select;
        }

        public void Tick()
        {
            Tick_SelectState();
            Tick_SelectCooldownState();
        }

        #endregion

        #region Private Methods

        private void Tick_SelectState()
        {
            if (State != ActionState.Select) return;

            Tick_Select_Active();
            Tick_Select_Condition();
        }

        private void Tick_SelectCooldownState()
        {
            if (State != ActionState.SelectCooldown) return;

            Tick_Select_Cooldown();
            Tick_SelectCooldown_Transition();
        }

        private void Tick_Select_Active()
        {
            Select();
            selectActiveFrame -= 1;
        }

        private void Tick_Select_Cooldown()
        {
            SelectCooldown();
            selectCooldownFrame -= 1;
        }


        private void Tick_Select_Condition()
        {
            if (selectActiveFrame <= 0)
            {
                State = ActionState.SelectCooldown;
            }
        }

        private void Tick_SelectCooldown_Transition()
        {
            if (selectCooldownFrame <= 0)
            {
                State = ActionState.Idle;
            }
        }

        private void Select()
        {
            Debug.Log("Select");
        }

        private void SelectCooldown()
        {
        }

        #endregion
    }
}