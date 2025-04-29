using UnityEngine;
using Zenject;

namespace Gameplay.Input.Core
{
    public interface IInputService
    {
        IInputTrack InputTrack { get; set; }
        void        SetPointerPosition(Vector2 readValue);
    }

    public class InputService : IInputService
    {
        [Inject] public IInputTrack InputTrack { get; set; }
        [Inject] public IInputState InputState { get; set; }

        public void SetPointerPosition(Vector2 readValue)
        {
            InputState.PointerPosition = readValue;
        }
    }
}
