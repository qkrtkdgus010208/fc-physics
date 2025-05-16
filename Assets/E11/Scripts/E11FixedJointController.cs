using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class E11FixedJointController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isConnected = false;
    private FixedJoint joint;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (joint == null)
        {
            // Ray를 아래 방향으로 쏘기
            Ray ray = new Ray(transform.position, Vector3.down);
            float rayLength = 1f;

            // Raycast를 통해 Doll 태그 오브젝트 감지
            if (Physics.Raycast(ray, out RaycastHit hit, rayLength) && hit.collider.CompareTag("Doll"))
            {
                // 해당 오브젝트에 FixedJoint 추가
                joint = hit.collider.gameObject.AddComponent<FixedJoint>();

                if (joint != null)
                {
                    // FixedJoint의 connectedBody에 rb 연결
                    joint.connectedBody = rb;
                    joint.breakForce = 1000f;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        float moveSpeed = 5f;

        // 이동
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);

        // 위로 이동
        if (Input.GetKey(KeyCode.Q))
        {
            rb.MovePosition(transform.position + Vector3.up * moveSpeed * Time.deltaTime);
        }

        // 아래로 이동
        // position.y가 1.5f보다 작아지지 않도록 제한
        if (Input.GetKey(KeyCode.E) && transform.position.y > 1.5f)
        {
            rb.MovePosition(transform.position + Vector3.down * moveSpeed * Time.deltaTime);
        }
    }
}
