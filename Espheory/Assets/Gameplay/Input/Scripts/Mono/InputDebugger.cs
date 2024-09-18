#region

using Gameplay.Input.Core;
using UnityEngine;
using Zenject;

#endregion

namespace Gameplay.Input.Mono
{
    public class InputDebugger : MonoBehaviour
    {
        #region Private Valiables

        [Inject] private IInputState inputState;

        #endregion

        #region Private Methods

        private void OnGUI()
        {
            GUILayout.Label($"Select Performing: {inputState.PerformingSelect > 0}");
            GUILayout.Label($"Select Pulsing: {inputState.PerformingSelect    == 1}");
            GUILayout.Label($"Select Frame: {inputState.PerformingSelect}");
            GUILayout.Label($"Pointer Position: {inputState.PointerPosition}");
        }

        #endregion
    }
}
