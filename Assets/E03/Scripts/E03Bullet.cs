using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class E03Bullet : MonoBehaviour
{
    [SerializeField] float forceMount = 10f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * forceMount);
    }

    private void Update()
    {
        if (transform.position.z > 100)
        {
            Destroy(gameObject);
        }   
    }
}
