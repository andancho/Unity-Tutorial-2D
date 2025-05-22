using UnityEngine;
using UnityEngine.UIElements;


public class StudyLog : MonoBehaviour
{
    public float moveSpeed = 0.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        //Input System (Old - Legacy)
        //�Է°��� ���� ��ӵ� �ý���
        //�̵� WASD or ȭ��ǥ
        //���� Space
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    moveSpeed = 1f;
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    //transform.position += Vector3.forward * moveSpeed * Time.deltaTime; //z�� �� �����̶� �þ߿� ���� ������ �ٲ�� 3d�� �������� ����
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

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        Debug.Log($"���� �Է� : {dir}");

        transform.position += dir * moveSpeed * Time.deltaTime;

    }
}
