using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EosPitchYaw : MonoBehaviour
{
    private float _rotationSpeed;
    public Transform pivot;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Reset()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) // 滑鼠左鍵
        {
            float mouseX = Input.GetAxis("Mouse X") * _rotationSpeed;
            float mouseY = -Input.GetAxis("Mouse Y") * _rotationSpeed;
            transform.RotateAround(pivot.position, Vector3.up, mouseX);
            transform.RotateAround(pivot.position, transform.right, mouseY);
        }
    }
}