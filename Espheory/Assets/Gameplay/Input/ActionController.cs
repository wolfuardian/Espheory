using Zenject;

namespace Gameplay.Input
{
    public interface IActionTracker
    {
        void        Perform();
        ActionState GetState();
        int         GetFrame();
        int         GetActiveFrames();
        int         GetCooldownFrames();
    }

    public class ActionTracker : IActionTracker, ITickable
    {
        private readonly int         activeFrames;
        private readonly int         cooldownFrames;
        private          ActionState state;
        private          int         currentFrame;

        public ActionTracker(int activeFrames, int cooldownFrames)
        {
            this.activeFrames   = activeFrames;
            this.cooldownFrames = cooldownFrames;
            state               = ActionState.Idle;
        }

        public void Perform()
        {
            if (state == ActionState.Idle)
            {
                state        = ActionState.Active;
                currentFrame = 0;
            }
        }

        public void Tick()
        {
            if (state == ActionState.Active)
            {
                currentFrame++;
                if (currentFrame >= activeFrames)
                {
                    state        = ActionState.Cooldown;
                    currentFrame = 0;
                }
            }
            else if (state == ActionState.Cooldown)
            {
                currentFrame++;
                if (currentFrame >= cooldownFrames)
                {
                    state        = ActionState.Idle;
                    currentFrame = 0;
                }
            }
        }

        public ActionState GetState()          => state;
        public int         GetFrame()          => currentFrame;
        public int         GetActiveFrames()   => activeFrames;
        public int         GetCooldownFrames() => cooldownFrames;
    }

    public enum ActionState
    {
        Idle,
        Active,
        Cooldown
    }

    public interface IActionController
    {
        IActionTracker Select { get; }
    }

    public class ActionController : IActionController, ITickable
    {
        public IActionTracker Select { get; } = new ActionTracker(300, 600);

        public void Tick()
        {
            (Select as ITickable)?.Tick();
        }
    }
}
