using UnityEngine;

namespace Gameplay.Navigate.Scripts
{
    internal interface INavState
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
