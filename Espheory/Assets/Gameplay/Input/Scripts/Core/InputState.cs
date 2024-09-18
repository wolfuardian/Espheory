using UnityEngine;

namespace Gameplay.Input.Core
{
    public interface IInputState
    {
        int     PerformingSelect { get; set; }
        Vector2 PointerPosition  { get; set; }
    }

    public class InputState : IInputState
    {
        public int     PerformingSelect { get; set; }
        public Vector2 PointerPosition  { get; set; }
    }
}
