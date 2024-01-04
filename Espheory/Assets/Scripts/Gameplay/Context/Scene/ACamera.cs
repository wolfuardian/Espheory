using Eos.Gameplay.Context.Main;
using UnityEngine;

namespace Eos.Gameplay.Context.Scene
{
    public class ACamera : AActor
    {
        public Camera GetCamera()
        {
            var component = GetComponent<Camera>();
            if (component == null)
            {
                Debug.LogError("ACamera: Missing Camera Component");
            }

            return component;
        }
    }
}