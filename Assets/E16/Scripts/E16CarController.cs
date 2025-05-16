using UnityEngine;

public class CarControl : MonoBehaviour
{
    public float motorTorque = 2000; // 모터 토크
    public float brakeTorque = 2000; // 브레이크 토크
    public float maxSpeed = 80; // 최대 속도
    public float steeringRange = 30; // 조향 범위
    public float steeringRangeAtMaxSpeed = 10; // 최대 속도에서의 조향 범위
    public float centreOfGravityOffset = -1f; // 중력 중심 오프셋

    E16WheelControl[] wheels; // 휠 컨트롤 배열
    Rigidbody rigidBody; // 리지드바디

    // 시작 전에 호출
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>(); // 리지드바디 컴포넌트 가져오기

        // 차량이 넘어지는 것을 방지하기 위해 질량 중심을 수직으로 조정
        rigidBody.centerOfMass += Vector3.up * centreOfGravityOffset;

        // WheelControl 스크립트가 첨부된 모든 자식 GameObject를 찾기
        wheels = GetComponentsInChildren<E16WheelControl>();
    }

    // 매 프레임마다 호출
    void Update()
    {
        float vInput = Input.GetAxis("Vertical"); // 수직 입력
        float hInput = Input.GetAxis("Horizontal"); // 수평 입력

        // 차량의 전방 방향에 대한 현재 속도 계산
        // (뒤로 이동할 때 음수 반환)
        float forwardSpeed = Vector3.Dot(transform.forward, rigidBody.velocity);

        // 최고 속도에 대한 차량의 현재 속도 계산
        // 0에서 1 사이의 숫자로
        float speedFactor = Mathf.InverseLerp(0, maxSpeed, forwardSpeed);

        // 그것을 사용하여 사용 가능한 토크를 계산
        // (최고 속도에서 토크는 0)
        float currentMotorTorque = Mathf.Lerp(motorTorque, 0, speedFactor);

        // …그리고 조향을 얼마나 해야 하는지 계산
        // (차량은 최고 속도에서 더 부드럽게 조향)
        float currentSteerRange = Mathf.Lerp(steeringRange, steeringRangeAtMaxSpeed, speedFactor);
        // 사용자 입력이 차량의 속도와 같은 방향인지 확인
        bool isAccelerating = Mathf.Sign(vInput) == Mathf.Sign(forwardSpeed);

        foreach (var wheel in wheels)
        {
            // "조향 가능"이 활성화된 Wheel collider에 조향 적용
            if (wheel.steerable)
            {
                wheel.WheelCollider.steerAngle = hInput * currentSteerRange;
            }

            if (isAccelerating)
            {
                // "모터화"가 활성화된 Wheel collider에 토크 적용
                if (wheel.motorized)
                {
                    wheel.WheelCollider.motorTorque = vInput * currentMotorTorque;
                }
                wheel.WheelCollider.brakeTorque = 0;
            }
            else
            {
                // 사용자가 반대 방향으로 가려고 하면
                // 모든 휠에 브레이크 적용
                wheel.WheelCollider.brakeTorque = Mathf.Abs(vInput) * brakeTorque;
                wheel.WheelCollider.motorTorque = 0;
            }
        }
    }
}