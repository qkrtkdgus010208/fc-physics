using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E02Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"OnCollisionEnter [{ gameObject.name }] > [{ collision.gameObject.name }]");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTriggerEnter [{ gameObject.name }] > [{ other.gameObject.name }]");
    }
}
