using Zenject;
using UnityEngine;

namespace Gameplay.Navigate.Scripts
{
    public class NavTest1StraightTarget : MonoBehaviour
    {
        [Inject(Id = "NavPoint")]
        private Transform[] points;

        [Inject]
        private INavService navService;

        // private int index     = 0;
        // private int tickCount = 0;

        private void Update()
        {
            // if (tickCount % 1000 == 0 && tickCount < 10000)
            // {
            //     navService.Navigate(points[index]);
            //     index = (index + 1) % points.Length;
            // }
            //
            // tickCount++;
        }
    }
}
