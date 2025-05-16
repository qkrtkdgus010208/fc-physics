using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class E10CharacterController : MonoBehaviour
{
    public float speed = 6.0f;
    public float rotationSpeed = 180.0f; // Added rotation speed variable
    public float gravity = -9.81f;
    public float jumpHeight = 2.0f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (velocity.y > 0.5)
            Debug.Log("Velocity Y: " + velocity.y);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.5f;     // Junil: isGround 판정이 잘 안 나기 때문에 0 > -0.5로 수정
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Rotate the character based on horizontal input
        transform.Rotate(0, x * rotationSpeed * Time.deltaTime, 0);

        Vector3 move = transform.forward * z; // Move only in the forward direction
        controller.Move(move * (speed * Time.deltaTime));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jump");
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
