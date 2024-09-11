using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.Input
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
        }
    }
}
