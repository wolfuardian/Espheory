using UnityEngine;

namespace Gameplay.Nav.Core
{
    public interface INavState
    {
        bool      IsNavigateNext { get; set; }
        Transform GetNextTarget  { get; set; }
    }

    public class NavState : INavState
    {
        public bool      IsNavigateNext { get; set; }
        public Transform GetNextTarget  { get; set; }
    }
}
