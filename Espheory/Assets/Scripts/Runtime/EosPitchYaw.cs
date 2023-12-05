using System;
using UnityEngine;

namespace Eos.Scripts.Runtime
{
    public class EosPitchYaw : MonoBehaviour
    {
        private float _rotationSpeed;
        public Transform pivot;

        void Start()
        {
        }

        private void Reset()
        {
            throw new NotImplementedException();
        }

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                float mouseX = Input.GetAxis("Mouse X") * _rotationSpeed;
                float mouseY = -Input.GetAxis("Mouse Y") * _rotationSpeed;
                transform.RotateAround(pivot.position, Vector3.up, mouseX);
                transform.RotateAround(pivot.position, transform.right, mouseY);
            }
        }
    }
}