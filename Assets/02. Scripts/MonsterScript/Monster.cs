using System;
using System.Collections;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    SpriteRenderer sRenderer; // 스프라이트 렌더러 컴포넌트
    private Animator animator; // 애니메이터 컴포넌트

    [SerializeField] protected float hp; // 몬스터의 체력
    [SerializeField] protected float moveSpeed; // 몬스터의 이동 속도
    [SerializeField] private SpawnManager SpawnManager; // 스폰 매니저

    public int dir = 1; //방향값
    private bool isMove = true;
    private bool isHit = false; // 몬스터가 맞았는지 여부

    public abstract void Init();
    public void SetFlip(int dir)
    {
        if (dir > 0)
            sRenderer.flipX = false;
        else
            sRenderer.flipX = true;
    }
    public int Dir
    {
        get { return dir; }
        set { dir = value; }
    }

    private void Awake()
    {
        SpawnManager = FindFirstObjectByType<SpawnManager>(); // 스폰 매니저 찾기

        sRenderer = GetComponent<SpriteRenderer>(); // 스프라이트 렌더러 컴포넌트 가져오기
        animator = GetComponent<Animator>(); // 애니메이터 컴포넌트 가져오기

        Init(); // 초기화 함수 호출

    }
    private void Update()
    {
        Move(); // 이동 함수 호출
    }

    private void OnMouseDown()
    {

        StartCoroutine(Hit(1));
    }

    void Move()  //자동 이동
    {
        if (!isMove) // 이동하지 않는 상태일 때
            return; // 함수 종료

        transform.position += Vector3.right * dir * moveSpeed * Time.deltaTime; // 왼쪽으로 이동

        if (transform.position.x > 8f)
        {
            dir = -1; // 방향을 반대로 바꿈
            sRenderer.flipX = true; // 스프라이트를 좌우 반전
        }
        else if (transform.position.x < -8f)
        {
            dir = 1; // 방향을 반대로 바꿈
            sRenderer.flipX = false; // 스프라이트를 좌우 반전
        }

    }
    public IEnumerator Hit(float damage)
    {
        if (isHit)
            yield break;

        isHit = true;
        isMove = false;

        hp -= damage;

        if (hp <= 0)
        {
            animator.SetTrigger("Death");

            SpawnManager.DropCoin(transform.position); // 코인 드랍
            yield return new WaitForSeconds(3f);
            gameObject.SetActive(false); // 몬스터 비활성화

            yield break;
        }

        animator.SetTrigger("Hit");

        yield return new WaitForSeconds(0.65f);
        isHit = false;
        isMove = true;
    }
}


