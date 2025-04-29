using UnityEngine;

namespace Espheory
{
    public interface IInputState
    {
        bool IsSelecting { get; set; }
        Vector2 Pointer { get; set; }
    }

    public class PlayerInputState : IInputState
    {
        public bool IsSelecting
        {
            get;
            set;
        }
        public Vector2 Pointer
        {
            get;
            set;
        }
    }
}
