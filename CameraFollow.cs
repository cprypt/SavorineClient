using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // 플레이어 Transform
    public float smoothSpeed = 0.125f;  // 부드러운 이동 속도
    public Vector3 offset;  // 카메라와 플레이어 사이의 오프셋

    void LateUpdate()
    {
        // 카메라의 목표 위치 계산
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;  // 카메라 위치 이동
    }
}
