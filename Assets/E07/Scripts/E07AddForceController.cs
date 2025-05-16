using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E07AddForceController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5f; // 이동 속도
    public float rotationSpeed = 100f; // 회전 속도

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Move forward and backward
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * (speed * Time.deltaTime));
        }

        // Rotate left and right
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Add relative force when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb != null)
            {
                rb.AddForce(Vector3.forward * 1000f);
            }
        }
    }
}