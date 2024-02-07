using UnityEngine;
using Eos.Gameplay.Context.Main;

namespace Eos.Gameplay.Context.Scene
{
    public class ACursor : AActor
    {
        public void SetPosition(Vector3 pointerPosition)
        {
            transform.position = pointerPosition;
        }


    }
}