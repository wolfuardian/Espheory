using Zenject;

namespace Gameplay.AI.Scripts
{
    public interface INavService
    {
        void Target();
        void Navigate();
    }

    public class NavService : INavService
    {
        [Inject]
        private INavController m_NavController;

        public void Target()   => m_NavController.Target();
        public void Navigate() => m_NavController.Navigate();
    }
}
