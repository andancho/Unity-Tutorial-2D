using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed; // 배경 이동속도

    void Start()
    {
        
    }


    void Update()
    {
        //transform.position += Vector3.left * moveSpeed * Time.deltaTime;    //배경 왼쪽으로 이동

        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;   //델타타임의 불안정한 값 변동으로 인한 실선이슈 해결을 위해 값을 고정하는 Fixed를 사용
        Debug.Log(Time.fixedDeltaTime); // 프레임당 시간 출력

        if (transform.position.x <= -30f) // 배경이 왼쪽으로 30만큼 이동하면
        {
            transform.position = new Vector3(30f, transform.position.y, transform.position.z); // 배경을 오른쪽으로 옮김
        }

    }
}
