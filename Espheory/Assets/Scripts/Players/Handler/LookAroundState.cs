using UnityEngine;

namespace Eos.Players.Handler
{
    public class LookAroundState
    {
        public  float CooldownDuration { get; private set; } = 0.1f;
        private bool  _isActive = false;

        public float CooldownTimer { get; private set; }

        public void Cooldown()
        {
            CooldownTimer = CooldownDuration;
            _isActive     = false;
        }

        public void Update()
        {
            if (CooldownTimer > 0)
            {
                CooldownTimer -= Time.deltaTime;
                CooldownTimer =  CooldownTimer < 0 ? 0 : CooldownTimer;
            }
        }

        public bool Active
        {
            get => _isActive;
            set
            {
                if (value)
                {
                    if (IsCooldownComplete())
                    {
                        _isActive = true;
                    }
                }
                else
                {
                    _isActive = false;
                }
            }
        }

        public bool IsCooldownComplete() => CooldownTimer <= 0;
    }
}