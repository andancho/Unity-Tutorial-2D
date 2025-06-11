using Cat_Game;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Cat_Controller : MonoBehaviour
{
    Rigidbody2D catRb;
    Animator catAnim;

    public GameObject winVideo;
    public GameObject loseVideo;

    public GameObject gameOverUI;
    public GameObject fadeUI;

    public float jumpForce = 20f;
    public float limitPower = 15f; // 점프 힘의 한계값
    public bool isGround = false;
    public int jumpCount = 0;
    public SoundManager soundManager; // 사운드 매니저를 참조하기 위한 변수

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            Jump();
            jumpCount++;
            soundManager.OnJumpSound(); // 점프 사운드 재생

            if (catRb.linearVelocityY > limitPower) // 자연스러운 점프를 위한 속도 제한
                catRb.linearVelocityY = limitPower;
        }
        var catRotation = transform.eulerAngles;
        catRotation.z = catRb.linearVelocityY * 1.5f;
        transform.eulerAngles = catRotation; // 고양이의 회전 설정
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Debug.Log("사과 획득");
            GameManager.score++; // 점수 증가
            collision.gameObject.SetActive(false); // 사과 오브젝트 끄기
            collision.transform.parent.GetComponent<ItemEvent>().particle.SetActive(true); // 사과 획득 이펙트 활성화

            if (GameManager.score == 10)
            {
                fadeUI.SetActive(true); // Fade UI 활성화
                fadeUI.GetComponent<FadePanel>().OnFade(1.5f, Color.white);
                this.GetComponent<CircleCollider2D>().enabled = false; // 충돌 감지 비활성화
                Invoke("WinVideo", 1.5f); // 승리 비디오 재생 호출
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", true); // 바닥에 닿았을 때 애니메이션 상태 변경

            isGround = true;
            jumpCount = 0; // 땅에 닿으면 점프 횟수 초기화
        }

        if (collision.gameObject.CompareTag("Pipe"))
        {
            Debug.Log("부딪힘");
            GameManager.isPlay = false; // 게임이 끝났음을 알림
            soundManager.OnColliderSound(); // 게임 오버 사운드 재생
            gameOverUI.SetActive(true); // 게임 오버 UI 활성화
            fadeUI.SetActive(true); // Fade UI 활성화
            fadeUI.GetComponent<FadePanel>().OnFade(1.5f, Color.black);
            this.GetComponent<CircleCollider2D>().enabled = false; // 충돌 감지 비활성화

            Invoke("LoseVideo", 1.5f); // 게임 오버 비디오 재생 호출
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
    void Jump()
    {
        if (catRb != null)
        {
            catAnim.SetBool("isGround", false); // 점프 애니메이션 상태 변경
            catRb.AddForceY(jumpForce, ForceMode2D.Impulse);
            catAnim.SetTrigger("Jump"); // 점프 애니메이션 트리거 설정
        }
    }

    public void WinVideo()
    {
        winVideo.SetActive(true); // 승리 비디오 활성화
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false); // 게임 오버 UI 비활성화

        soundManager.audioSource.mute = true;
    }

    public void LoseVideo()
    {
        loseVideo.SetActive(true); // 승리 비디오 활성화
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false); // 게임 오버 UI 비활성화

        soundManager.audioSource.mute = true;
    }
}
