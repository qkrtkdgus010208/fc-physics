using UnityEngine;

public class E16WheelControl : MonoBehaviour
{
    public Transform wheelModel; // 휠 모델

    [HideInInspector] public WheelCollider WheelCollider; // 휠 콜라이더

    // CarControl 스크립트를 위한 속성 생성
    // (이들은 에디터 인스펙터 창을 통해 활성화/비활성화해야 합니다)
    public bool steerable; // 조향 가능 여부
    public bool motorized; // 모터화 여부

    Vector3 position; // 위치
    Quaternion rotation; // 회전

    // 첫 프레임 업데이트 전에 호출
    private void Start()
    {
        WheelCollider = GetComponent<WheelCollider>(); // WheelCollider 컴포넌트 가져오기
    }

    // 매 프레임마다 호출
    void Update()
    {
        // WheelCollider의 월드 포즈 값을 가져와서
        // 휠 모델의 위치와 회전을 설정
        // 휠 콜라이더의 위치에 맞게 휠 모델을 이동
        WheelCollider.GetWorldPose(out position, out rotation);
        wheelModel.transform.position = position;
        wheelModel.transform.rotation = rotation;
    }
}