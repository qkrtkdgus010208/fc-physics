using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E15ConfigurableJointController : MonoBehaviour
{
    private ConfigurableJoint joint;
    private float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate new rotation
        float rotation = Mathf.Sin(Time.time * rotationSpeed) * 90f;

        // Apply new rotation to the joint
        joint.targetRotation = Quaternion.Euler(rotation, rotation, rotation);
    }
}