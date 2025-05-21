using UnityEngine;
using UnityEngine.UIElements;


public class StudyLog : MonoBehaviour
{
    public float moveSpeed = 0.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 1f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += Vector3.forward * moveSpeed * Time.deltaTime; //z축 값 변경이라 시야에 따라 방향이 바뀌는 3d에 적합하지 않음
            transform.position += transform.forward * moveSpeed * Time.deltaTime; 
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(0f, -7f*moveSpeed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * moveSpeed * 0.5f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(0f, 7f*moveSpeed * Time.deltaTime, 0f);
        }


    }
}
