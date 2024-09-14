using Zenject;
using UnityEngine;

namespace Gameplay.Input.Scripts
{
    public class InputDebugger : MonoBehaviour
    {
        [Inject]
        private IInputState inputState;

        private void OnGUI()
        {
            GUILayout.Label($"Select Performing: {inputState.IsSelectPerforming}");
            GUILayout.Label($"Select Pressed: {inputState.IsSelectPressed}");
            GUILayout.Label($"Select Frame: {inputState.SelectPerforming}");
        }
    }
}
