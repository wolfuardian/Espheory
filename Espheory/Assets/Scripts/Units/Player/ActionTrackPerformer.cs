using Zenject;
using UnityEngine;

namespace Gameplay.Player.Core
{
    public enum EActionState
    {
        Idle,
        Activate,
        Performing,
        Cooldown
    }

    public interface IActionTrackPerformer
    {
        void         Perform();
        float        RemainingTime { get; set; }
        float        ActivateTime  { get; set; }
        float        CooldownTime  { get; set; }
        EActionState State         { get; set; }
    }

    public class ActionTrackPerformer : IActionTrackPerformer, ITickable
    {
        public float        RemainingTime { get; set; }
        public float        ActivateTime  { get; set; } = 1.0f; // 這裡要想辦法外部化
        public float        CooldownTime  { get; set; } = 1.5f; // 這裡要想辦法外部化
        public EActionState State         { get; set; }

        private float currentTime;

        public void Perform()
        {
            if (State == EActionState.Idle)
            {
                State         = EActionState.Activate;
                RemainingTime = ActivateTime;
                currentTime   = 0.0f;
            }
        }

        public void Tick()
        {
            if (State == EActionState.Activate)
            {
                currentTime   += Time.deltaTime;
                RemainingTime =  ActivateTime - currentTime;
                if (currentTime >= ActivateTime)
                {
                    State         = EActionState.Performing;
                    RemainingTime = CooldownTime;
                    currentTime   = 0.0f;
                }
            }
            else if (State == EActionState.Performing)
            {
                State         = EActionState.Cooldown;
                RemainingTime = 0.0f;
                currentTime   = 0.0f;
            }
            else if (State == EActionState.Cooldown)
            {
                currentTime   += Time.deltaTime;
                RemainingTime =  CooldownTime - currentTime;
                if (currentTime >= CooldownTime)
                {
                    State         = EActionState.Idle;
                    RemainingTime = 0.0f;
                    currentTime   = 0.0f;
                }
            }
        }
    }
}
