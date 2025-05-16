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
            // Ray�� �Ʒ� �������� ���
            Ray ray = new Ray(transform.position, Vector3.down);
            float rayLength = 1f;

            // Raycast�� ���� Doll �±� ������Ʈ ����
            if (Physics.Raycast(ray, out RaycastHit hit, rayLength) && hit.collider.CompareTag("Doll"))
            {
                // �ش� ������Ʈ�� FixedJoint �߰�
                joint = hit.collider.gameObject.AddComponent<FixedJoint>();

                if (joint != null)
                {
                    // FixedJoint�� connectedBody�� rb ����
                    joint.connectedBody = rb;
                    joint.breakForce = 1000f;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        float moveSpeed = 5f;

        // �̵�
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);

        // ���� �̵�
        if (Input.GetKey(KeyCode.Q))
        {
            rb.MovePosition(transform.position + Vector3.up * moveSpeed * Time.deltaTime);
        }

        // �Ʒ��� �̵�
        // position.y�� 1.5f���� �۾����� �ʵ��� ����
        if (Input.GetKey(KeyCode.E) && transform.position.y > 1.5f)
        {
            rb.MovePosition(transform.position + Vector3.down * moveSpeed * Time.deltaTime);
        }
    }
}
