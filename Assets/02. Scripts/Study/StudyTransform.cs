using UnityEngine;

public class StudyTransform : MonoBehaviour
{
    public float moveSpeed = 10f; // 이동 속도 변수
    public float rotateSpeed = 70f; // 회전 속도 변수


    void Start()
    {
        
    }

    
    void Update()
    {
        //transform.position += Vector3.forward * moveSpeed * Time.deltaTime; // 월드의 forward 방향으로 이동

        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World); // 월드의 forward 방향으로 이동

        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);  // 로컬의 forward 방향으로 이동


        // 월드 방향으로 회전
        //transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);

        // 로컬 방향으로 회전
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime); // 월드의 Y축을 기준으로 회전

        //특정위치 주변을 회전(특정 좌표 ,       축,              속도)
        transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime); // 월드의 Y축을 기준으로 회전

        //특정 위치를 바라보게 하기
        transform.LookAt(Vector3.zero); // 월드의 원점(0,0,0)을 바라보게 함
    }
}
