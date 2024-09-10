using Zenject;
using UnityEngine.InputSystem;

namespace Modules.Scripts
{
    public interface IInputHandler
    {
        void OnSelect(InputAction.CallbackContext  context);
        void OnPointer(InputAction.CallbackContext context);
    }

    public class InputHandler : IInputHandler, ITickable
    {
        [Inject]
        private IKeyboard keyboard;

        [Inject]
        private IInputState inputState;

        public void OnSelect(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    break;
                case InputActionPhase.Performed:
                    keyboard.TrackSelect.SetKeyPerforming(true);
                    break;
                case InputActionPhase.Canceled:
                    keyboard.TrackSelect.SetKeyPerforming(false);
                    break;
            }
        }

        public void OnPointer(InputAction.CallbackContext context)
        {
        }

        public void Tick()
        {
            inputState.IsSelectPerforming = keyboard.TrackSelect.IsKeyPerforming();
            inputState.IsSelectPressed    = keyboard.TrackSelect.IsKeyPressed();
            inputState.SelectPerforming   = keyboard.TrackSelect.GetKeyFrame();
        }
    }
}
