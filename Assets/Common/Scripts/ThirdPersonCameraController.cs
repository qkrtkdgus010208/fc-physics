using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float height = 2f;
    public float smoothSpeed = 0.5f;

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0f, height, -distance);
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
