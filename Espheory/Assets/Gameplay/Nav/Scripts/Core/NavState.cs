using UnityEngine;

namespace Gameplay.Nav.Core
{
    public interface INavState
    {
        bool    IsNavigateNext { get; set; }
        Vector3 GetNextTarget  { get; set; }
    }

    public class NavState : INavState
    {
        public bool    IsNavigateNext { get; set; }
        public Vector3 GetNextTarget  { get; set; }
    }
}
