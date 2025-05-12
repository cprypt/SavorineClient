using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // 이동 속도
    private Rigidbody2D rb;       // Rigidbody2D 컴포넌트
    private Vector2 movement;     // 이동 방향

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Rigidbody2D 컴포넌트 가져오기
    }

    void Update()
    {
        // 사용자 입력 받기
        movement.x = Input.GetAxisRaw("Horizontal");  // 좌우 이동
        movement.y = Input.GetAxisRaw("Vertical");    // 상하 이동
    }

    void FixedUpdate()
    {
        // 물리 기반 이동
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
