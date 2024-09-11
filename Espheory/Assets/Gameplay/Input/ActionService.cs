using Zenject;

namespace Gameplay.Input
{
    public interface IActionService
    {
        void        Select();
        ActionState GetSelectState();
        int         GetSelectFrame();
        int         GetSelectActiveFrames();
        int         GetSelectCooldownFrames();
    }

    public class ActionService : IActionService
    {
        [Inject]
        private IActionController actionController;

        public void Select()                  => actionController.Select.Perform();
        public int  GetSelectFrame()          => actionController.Select.GetFrame();
        public int  GetSelectActiveFrames()   => actionController.Select.GetActiveFrames();
        public int  GetSelectCooldownFrames() => actionController.Select.GetCooldownFrames();

        public ActionState GetSelectState() => actionController.Select.GetState();
    }
}
