using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class KnightController_KeyBoard : MonoBehaviour
{
    Animator animator;
    Rigidbody2D knightRb;
    Vector3 inputDir;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpPower = 10f;

    bool isGround;

    private void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
    }
    void Update()   //일반적인 작업
    {
        InputKeyBoard();
    }

    void FixedUpdate()  //물리적인 작업
    {
        Move();
    }

    void InputKeyBoard()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        inputDir = new Vector3(h, v, 0);
        Jump();
        SetAnimation();

        
    }
    void Move() //RigidBody를 활용한 물리적 이동
    {
         knightRb.linearVelocityX = inputDir.x * moveSpeed;
        
    }
    void SetAnimation()
    {
        if (inputDir.x != 0)
        {
            animator.SetBool("isRun", true);
            var scaleX = inputDir.x > 0 ? 1 : -1; //h의 값이 양수면 1, 음수면 -1
            transform.localScale = new Vector3(scaleX, 1, 0);
        }
        else if (inputDir.x == 0)
            animator.SetBool("isRun", false);
    }
    void Jump()
    {
        //점프기능(물리 연산이지만 단발성 연산은 상관X)
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            animator.SetTrigger("Jump");
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
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
