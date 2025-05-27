using UnityEngine;

public class Roulette : MonoBehaviour
{
    public float spinSpeed; // 회전 속도 변수
    bool isStop = false;    // 회전 중지 여부 변수

    void Start()
    {
        spinSpeed = 0f; // 초기 회전 속도 설정

    }
    void Update()
    {
        
        transform.Rotate(Vector3.forward * -spinSpeed); // 회전 방향 설정

        if (Input.GetMouseButtonDown(0))    // 마우스 클릭 시 회전 시작
        {
            spinSpeed = 7f; // 마우스 클릭 시 회전 속도 설정
        }

        if (Input.GetKeyDown(KeyCode.Space))    // 스페이스바를 누르면 회전 중지
        {
            isStop = true;  // 회전 중지 플래그 설정

        }

       if (isStop == true)
        {
            spinSpeed *= 0.99f; // 회전 속도 감소
            if (spinSpeed <0.001f)  // 회전 속도가 거의 0에 가까워지면
            {
                spinSpeed = 0f; // 회전 속도를 0으로 설정
                isStop = false; // 회전이 멈추면 isStop을 false로 설정
            }
        }
        


    }
}
