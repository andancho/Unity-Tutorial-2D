using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Rigidbody2D carRb;
    private float h;

    void Update()
    {
        h = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        // 물리 엔진 업데이트를 위한 고정된 시간 간격에서의 로직
        // 현재는 Update에서 처리하고 있으므로 비워둡니다.
        carRb.linearVelocityX = h * moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log($"{other.gameObject.name} Collision Enter");
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log($"{other.gameObject.name} Collision Stay");
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log($"{other.gameObject.name} Collison Exit");
    }
}

