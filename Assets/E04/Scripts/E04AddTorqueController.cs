using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E04AddTorqueController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float forceMount = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Rotate the object using AddTorque
        rb.AddTorque(Vector3.forward * (forceMount * Time.deltaTime));
    }
}
