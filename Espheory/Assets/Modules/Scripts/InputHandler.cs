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
            if (context.started)
                keyboard.TrackSelect.SetKeyDown(true);
            if (context.canceled)
                keyboard.TrackSelect.SetKeyDown(false);
        }

        public void OnPointer(InputAction.CallbackContext context)
        {
        }

        public void Tick()
        {
            inputState.IsSelectPerforming = keyboard.TrackSelect.IsKeyPerforming();
            inputState.IsSelectPressed    = keyboard.TrackSelect.IsKeyPressed();
            inputState.IsSelectReleased   = keyboard.TrackSelect.IsKeyReleased();
            inputState.IsSelectCooldown   = keyboard.TrackSelect.IsKeyCooldown();
            inputState.IsSelectIdle       = keyboard.TrackSelect.IsKeyIdle();
        }
    }
}
