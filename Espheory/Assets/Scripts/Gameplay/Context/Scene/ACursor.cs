using Eos.Gameplay.Context.Main;
using UnityEngine;

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