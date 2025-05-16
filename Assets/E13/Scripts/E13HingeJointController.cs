using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E13HingeJointController : MonoBehaviour
{
    [SerializeField] private HingeJoint[] hinges;
    private JointMotor[] motors;
    private Rigidbody rb;
    private float moveSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        motors = new JointMotor[hinges.Length];

        for (int i=0; i < hinges.Length; i++)
        {
            hinges[i].useMotor = true;
            motors[i] = hinges[i].motor;
            motors[i].targetVelocity = -1000f;
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            for (int i=0; i < hinges.Length; i++)
            {
                motors[i].force = 500;
                hinges[i].motor = motors[i];
            }
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            for (int i=0; i<hinges.Length; i++)
            {
                motors[i].force = 0;
                hinges[i].motor = motors[i];
            }
        }
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        rb.MovePosition(transform.position + moveDirection * (moveSpeed * Time.deltaTime));

        if (Input.GetKey(KeyCode.Q))
        {
            rb.MovePosition(transform.position + Vector3.up * (moveSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.E))
        {
            rb.MovePosition(transform.position + Vector3.down * (moveSpeed * Time.deltaTime));
        }
    }
}