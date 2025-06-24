using System.Collections;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private GameObject hitBox;
    [SerializeField] private float moveSpeed = 3f;
    private float h, v;

    private bool isAttack = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
    }

    private void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        if (h == 0 && v == 0)
        {
            animator.SetBool("Run", false);
        }
        else
        {
            int scaleX = (h > 0) ? 1 : -1; // h의 값에 따라 x축 스케일 결정

            transform.localScale = new Vector3(scaleX, 1, 1); // x축 스케일 조정

            //if (h < 0)
            //    transform.localScale = new Vector3(-1, 1, 1);
            //else if (h > 0)
            //    transform.localScale = new Vector3(1, 1, 1);

            animator.SetBool("Run", true);

            var dir = new Vector3(h, v, 0).normalized;
            transform.position += dir * moveSpeed * Time.deltaTime;
        }

        
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttack)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    public IEnumerator AttackRoutine()
    {
        isAttack = true;
        hitBox.SetActive(true);
        
        yield return new WaitForSeconds(0.25f);
        hitBox.SetActive(false);
        isAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Monster>() != null)
        {
            Monster monster = other.GetComponent<Monster>();
            StartCoroutine(monster.Hit(1));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<IItem>() != null)
        {
            IItem item = other.gameObject.GetComponent<IItem>();
            item.Get(); // 아이템 획득
        }
    }

}
