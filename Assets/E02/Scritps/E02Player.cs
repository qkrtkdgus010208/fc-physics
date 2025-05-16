using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E02Player : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        Vector3 moveDirection = transform.forward * moveInput;
        rb.AddForce(moveDirection * moveSpeed);

        Vector3 rotation = new Vector3(0f, rotationInput * rotationSpeed, 0f);
        transform.Rotate(rotation * Time.deltaTime);
    }
}
