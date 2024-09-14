using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.Input.Scripts
{
    public class InputStateProvider : MonoBehaviour
    {
        [Inject]
        private IInputState inputState;

        [Inject]
        private IActionService actionService;

        public Text[] m_Texts;

        private void Update()
        {
            m_Texts[0].text = $"Select Performing: {inputState.IsSelectPerforming}";
            m_Texts[1].text = $"Select Pressed: {inputState.IsSelectPressed}";
            m_Texts[2].text = $"Select Frame: {inputState.SelectPerforming}";

            var maxFrames = 0;
            if (actionService.GetSelectState() == ActionState.Idle)
            {
                maxFrames = 1;
            }
            else if (actionService.GetSelectState() == ActionState.Active)
            {
                maxFrames = actionService.GetSelectActiveFrames();
            }
            else if (actionService.GetSelectState() == ActionState.Cooldown)
            {
                maxFrames = actionService.GetSelectCooldownFrames();
            }

            m_Texts[3].text = $"{actionService.GetSelectState()} : {1.0f - (actionService.GetSelectFrame() / (float)maxFrames):F1}";
            // m_Texts[2].text = $"Select Released: {inputState.IsSelectReleased}";

            // Debug.Log($"actionService.GetSelectState() = {actionService.GetSelectState()}");

            // m_Texts[3].text = $"Select Cooldown: {inputState.IsSelectCooldown}";
            // m_Texts[4].text = $"Select Idle: {inputState.IsSelectIdle}";
        }
    }
}
