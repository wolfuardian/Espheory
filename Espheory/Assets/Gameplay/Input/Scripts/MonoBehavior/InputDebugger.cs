#region

using Zenject;
using Gameplay.Input.Core;
using UnityEngine;

#endregion

namespace Gameplay.Input.MonoBehavior
{
    public class InputDebugger : MonoBehaviour
    {
        #region Private Valiables

        [Inject]
        private IInputState inputState;

        #endregion

        #region Private Methods

        private void OnGUI()
        {
            GUILayout.Label($"Select Performing: {inputState.PerformingSelect > 0}");
            GUILayout.Label($"Select Pulsing: {inputState.PerformingSelect    == 0}");
            GUILayout.Label($"Select Frame: {inputState.PerformingSelect}");
        }

        #endregion
    }
}
