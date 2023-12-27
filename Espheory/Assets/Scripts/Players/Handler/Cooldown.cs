using UnityEngine;

namespace Eos.Players.Handler
{
    public class Cooldown
    {
        public  float Duration { get; private set; }
        private float _timer;

        public Cooldown(float duration)
        {
            Duration = duration;
        }

        public void Update()
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
        }

        public void Start()
        {
            _timer = Duration;
        }

        public bool IsComplete()
        {
            return _timer <= 0;
        }
    }
}