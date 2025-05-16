using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E06AddForcePositionController : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb != null)
            {
                rb.AddForceAtPosition(Vector3.forward * 1000f, new Vector3(4f, 12f, 0f));
            }
        }
    }
}
