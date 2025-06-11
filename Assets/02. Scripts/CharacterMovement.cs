using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D characterRb;
    public SpriteRenderer[] renderers;

    public GameObject[] renderObjs;

    public float moveSpeed;
    public float jumpPower = 10f;
    private float h;

    public int jumpCount = 0; // 점프 횟수
    public bool isGround;

    void Start()
    {
        characterRb = GetComponent<Rigidbody2D>();

        renderers = GetComponentsInChildren<SpriteRenderer>(true);
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal"); // 키 입력

        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true; // 바닥에 닿았을 때
            renderers[2].gameObject.SetActive(false); // Idle
            jumpCount = 0; // 점프 횟수 초기화

        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false; // 바닥에서 떨어졌을 때

            renderers[0].gameObject.SetActive(false); // Idle
            renderers[1].gameObject.SetActive(false); // Run
            renderers[2].gameObject.SetActive(true); // Jump
        }
        
    }

    /// <summary>
    /// 캐릭터 움직임에 따라 이미지의 Flip 상태가 변하는 기능
    /// </summary>
    private void Move()
    {
        if (h > 0)
        {
            renderers[0].flipX = false;
            renderers[1].flipX = false;
            renderers[2].flipX = false; // 점프 이미지도 방향을 맞춤
        }
        else if (h < 0)
        {
            renderers[0].flipX = true;
            renderers[1].flipX = true;
            renderers[2].flipX = true; // 점프 이미지도 방향을 맞춤
        }

        if (!isGround)
            return; // 바닥에 닿지 않았으면 이동하지 않음

        if (h != 0) // 움직일 때
        {
            renderers[0].gameObject.SetActive(false); // Idle
            renderers[1].gameObject.SetActive(true); // Run

            characterRb.linearVelocityX = h * moveSpeed; // 물리적인 이동

            
        }
        else if (h == 0)// 움직이지 않을 때
        {
            renderers[0].gameObject.SetActive(true); // Idle
            renderers[1].gameObject.SetActive(false); // Run
        }
        
    }

    /// <summary>
    /// 캐릭터가 +Y 방향으로 점프하는 기능
    /// </summary>
    private void Jump()
    {
        if (Input.GetButtonDown("Jump")) // Input.GetKeyDown(KeyCode.Space)
        {
            if (!isGround&&jumpCount==1)
                DoubleJump();

            if (!isGround) // 바닥에 닿지 않았으면 점프하지 않음
                return;

            characterRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++; // 점프 횟수 증가

            renderers[0].gameObject.SetActive(false); // Idle
            renderers[1].gameObject.SetActive(false); // Run
            renderers[2].gameObject.SetActive(true); // Jump

        }
    }

    void DoubleJump()
    {
        if (jumpCount == 1)
        {
            characterRb.linearVelocityX = h * moveSpeed;
            characterRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++;
        }
    }
}