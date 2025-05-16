using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E08PositionController : MonoBehaviour
{
    public float speed = 5f; // 이동 속도

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, 0.0f, v);
        Vector3 newPosition = transform.position + movement * speed * Time.deltaTime;

        transform.position = newPosition;
    }

    //private void FixedUpdate()
    //{
    //    float h = Input.GetAxis("Horizontal");
    //    float v = Input.GetAxis("Vertical");

    //    Vector3 movement = new Vector3(h, 0.0f, v);
    //    Vector3 newPosition = transform.position + movement * speed * Time.fixedDeltaTime;

    //    transform.position = newPosition;
    //}
}
