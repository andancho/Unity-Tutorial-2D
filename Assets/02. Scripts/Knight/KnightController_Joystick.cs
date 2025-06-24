using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class KnightController_Joystick : MonoBehaviour
{
    Animator animator;
    Rigidbody2D knightRb;

    [SerializeField] Button jumpButton; //점프 버튼 UI 참조
    [SerializeField] Button attackButton;//공격 버튼 UI 참조
    [SerializeField] Button rollButton;

    Vector3 inputDir;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpPower = 10f;
    [SerializeField] float rollDistance = 5f; //롤 이동 거리

    bool isGround;
    bool isAttack;
    bool isCombo;

    bool canMove = true;
    bool isRoll;

    private void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();

        jumpButton.onClick.AddListener(Jump); //점프 버튼 클릭 시 Jump 메서드 호출
        attackButton.onClick.AddListener(Attack);//공격 버튼 클릭 시 Attack 메서드 호출
        rollButton.onClick.AddListener(Roll); //롤 버튼 클릭 시 Roll 메서드 호출
    }
    void Update()   //일반적인 작업
    {
        
    }
    void FixedUpdate()  //물리적인 작업
    {
        Move();
    }
    public void InputJoystick(float x, float y)
    {
        inputDir = new Vector3(x, y, 0).normalized; //Joystick에서 입력받은 x,y값을 inputDir에 저장

        animator.SetFloat("JoystickX", inputDir.x);
        animator.SetFloat("JoystickY", inputDir.y);

        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1; //h의 값이 양수면 1, 음수면 -1
            transform.localScale = new Vector3(scaleX, 1, 1);
        }
    }
    void Move() //RigidBody를 활용한 물리적 이동
    {
        if (!canMove)
            return;
        knightRb.linearVelocityX = inputDir.x * moveSpeed;

    }
    public void Jump()
    {
        //점프기능(물리 연산이지만 단발성 연산은 상관X)
        if (isGround)
        {
            animator.SetTrigger("Jump");
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }
    void Roll()
    {
        if (isRoll)
            return; //롤 중이거나 이동 불가 상태면 롤 실행하지 않음
        float rollDirection = transform.localScale.x > 0 ? 1 : -1; //현재 캐릭터의 방향에 따라 롤 방향 결정
        if (isGround)
        {
            isRoll = true; //롤 상태로 변경
            canMove = false; //롤 중에는 이동 불가
            animator.SetTrigger("Roll");

            knightRb.AddForceX(rollDistance * rollDirection, ForceMode2D.Impulse);

            //히트박스 제거 기능 추가 시 구르기 중 무적
        }
    }
    void EndRoll()
    {
        canMove = true; //롤이 끝나면 이동 가능
        isRoll = false; //롤 상태 해제
    }
    void Attack()
    {
        if (!isAttack)
        {
            Debug.Log("1타");
            isAttack = true; //공격 상태로 변경
            animator.SetTrigger("Attack");
        }
        else
        {
            isCombo = true; //콤보 상태로 변경
            isAttack = false; //공격 상태 해제
        }
    }
    public void CheckCombo()
    {
        if (isCombo)
        {
            Debug.Log("2타");
            animator.SetBool("isCombo", true);
        }
        else
        {
            Debug.Log("공격 종료");
            animator.SetBool("isCombo", false);
            isAttack = false; //공격 상태 해제
        }
    }
    void EndCombo()
    {
        isAttack = false; //콤보가 끝나면 공격 상태 해제
        isCombo = false; //콤보 상태 해제

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Ground", true);
            isGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Ground", false);
            isGround = false;
        }
    }
}
