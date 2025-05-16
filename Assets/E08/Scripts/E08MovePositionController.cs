using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class E08MovePositionController : MonoBehaviour
{
    public float speed = 5f; // 이동 속도
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, 0.0f, v);
        Vector3 newPosition = rb.position + movement * speed * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);
    }
}
