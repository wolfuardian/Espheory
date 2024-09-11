using UnityEngine.InputSystem;
using Zenject;

namespace Gameplay.Input
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
                    keyboard.Select.SetKeyPerforming(true);
                    break;
                case InputActionPhase.Canceled:
                    keyboard.Select.SetKeyPerforming(false);
                    break;
            }
        }

        public void OnPointer(InputAction.CallbackContext context)
        {
        }

        public void Tick()
        {
            inputState.IsSelectPerforming = keyboard.Select.IsKeyPerforming();
            inputState.IsSelectPressed    = keyboard.Select.IsKeyPressed();
            inputState.SelectPerforming   = keyboard.Select.GetKeyFrame();
        }
    }
}
