using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class E16Wheel
{
    public WheelCollider WheelCollider;
    public Transform WheelModel;
    public bool IsFrontWheel;
}

[RequireComponent(typeof(Rigidbody))]
public class E16WheeColliderController : MonoBehaviour
{
    [SerializeField] private E16Wheel[] wheels;
    private Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass += Vector3.up * -1f;
    }

    private void Update()
    {
        float v = Input.GetAxis("Vertical"); // 수직 입력
        float h = Input.GetAxis("Horizontal"); // 수평 입력
        
        // WheelCollider의 월드 포즈 값을 가져와서
        // 휠 모델의 위치와 회전을 설정
        foreach (var wheel in wheels)
        {
            if (wheel.IsFrontWheel)
            {
                wheel.WheelCollider.steerAngle = h * 30;
            }

            if (!wheel.IsFrontWheel)
            {
                wheel.WheelCollider.motorTorque = v * 2000;
            }
            
            wheel.WheelCollider.GetWorldPose(out var position, out var rotation);
            wheel.WheelModel.position = position;
            wheel.WheelModel.rotation = rotation;   
        }
    }
}
