using Zenject;

namespace Gameplay.Battle.Core
{
    public class DamageTriggerService
    {
        [Inject] private readonly DamageHandler damageHandler;

        // 當玩家進入觸發區域時調用
        public void OnPlayerEnter()
        {
            damageHandler.StartPlayerDamage();
        }

        // 當玩家離開觸發區域時調用
        public void OnPlayerExit()
        {
            damageHandler.StopPlayerDamage();
        }
    }
}
