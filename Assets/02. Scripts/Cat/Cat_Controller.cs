using Cat_Game;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Cat_Controller : MonoBehaviour
{
    Rigidbody2D catRb;
    Animator catAnim;

    public VideoManager videoManager;

    public GameObject gameOverUI;
    public GameObject fadeUI;

    public float jumpForce = 20f;
    public float limitPower = 15f; // 점프 힘의 한계값
    public bool isGround = false;
    public int jumpCount = 0;
    public SoundManager soundManager; // 사운드 매니저를 참조하기 위한 변수

    void Awake()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        transform.localPosition = new Vector3(-4.68805f, 1.155351f, -0.4674037f); // 고양이 위치 초기값으로 설정(초기화)
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
                fadeUI.GetComponent<FadePanel>().OnFade(3f, Color.white, true);
                this.GetComponent<CircleCollider2D>().enabled = false; // 충돌 감지 비활성화

                StartCoroutine(EndingRoutine(true));
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
            fadeUI.GetComponent<FadePanel>().OnFade(3f, Color.black, false);
            this.GetComponent<CircleCollider2D>().enabled = false; // 충돌 감지 비활성화
            
            StartCoroutine(EndingRoutine(false));
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

    IEnumerator EndingRoutine(bool isWin)
    {
        Debug.Log("코루틴 준비");
        yield return new WaitForSeconds(3f);
        Debug.Log("코루틴 1차 대기");

        videoManager.VideoPlay(isWin); // 영상 재생 시작
        //yield return new WaitForSeconds(1f);
        Debug.Log("코루틴 2차 대기");


        var newColor = isWin ? Color.white : Color.black;
        fadeUI.GetComponent<FadePanel>().OnFade(3f, newColor, false); // 페이드 실행

        //yield return new WaitForSeconds(3f);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        soundManager.audioSource.Stop();
        // soundManager.audioSource.mute = true; // 음소거

        transform.parent.gameObject.SetActive(false); // PLAY 오브젝트 Off
        Debug.Log("영상 재생 완료");

    }

}
