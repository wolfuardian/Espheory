using System;
using Gameplay.Player.Core;
using UnityEngine;
using Zenject;

namespace Gameplay.Player.Mono
{
    public class PlayerDebugger : MonoBehaviour
    {
        [Inject] private IActionState actionState;

        private void OnGUI()
        {
            GUILayout.Label($"TpSelect Remaining Time: {actionState.TpSelect.RemainingTime}"); // 每個階段剩餘時間
            GUILayout.Label($"TpSelect Activate Time: {actionState.TpSelect.ActivateTime}"); // 每個階段剩餘時間
            GUILayout.Label($"TpSelect Cooldown Time: {actionState.TpSelect.CooldownTime}"); // 詠唱時間
            GUILayout.Label($"TpSelect State: {actionState.TpSelect.State}"); // 冷卻時間
            // GUILayout.Label($"TpSelect Time: {action.TpSelect.State = EActionState.Idle}");
        }

        private void Update()
        {
            if (actionState.TpSelect.State == EActionState.Performing)
            {
                Debug.Log("TpSelect Performing");
            }
        }
    }
}
