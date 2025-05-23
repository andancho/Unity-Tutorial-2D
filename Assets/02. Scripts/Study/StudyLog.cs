using UnityEngine;
using UnityEngine.UIElements;


public class StudyLog : MonoBehaviour
{
    public float moveSpeed = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        //Input System (Old - Legacy)
        //입력값에 대한 약속된 시스템
        //이동 WASD or 화살표
        //점프 Space
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    moveSpeed = 1f;
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    //transform.position += Vector3.forward * moveSpeed * Time.deltaTime; //z축 값 변경이라 시야에 따라 방향이 바뀌는 3d에 적합하지 않음
        //    transform.position += transform.forward * moveSpeed * Time.deltaTime; 
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    this.transform.Rotate(0f, -7f*moveSpeed * Time.deltaTime, 0f);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position += -transform.forward * moveSpeed * 0.5f * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    this.transform.Rotate(0f, 7f*moveSpeed * Time.deltaTime, 0f);
        //}

        //키 입력에 따라 수치가 천천히 변함 (0 > 다양한 소수 > 1)
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 키 입력 시 1, 미 입력시 0
        // float h = Input.GetAxisRaw("Horizontal");
        // float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        Vector3 normalDir = dir.normalized; //  정규화 과정 (0 ~ 1)
        Debug.Log($"현재 입력 : {normalDir}");

        transform.position += normalDir * moveSpeed * Time.deltaTime;
        
        transform.LookAt(transform.position + normalDir); // 현재 위치 + 방향으로 바라보게 함

    }
}
