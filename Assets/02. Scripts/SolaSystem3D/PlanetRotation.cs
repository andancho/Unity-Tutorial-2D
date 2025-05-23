using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public Transform targetPlanet; // 타겟 행성

    public float rotSpeed = 5f;  // 자전 속도
    public float RevolutionSpeed = 1f; // 공전 속도

    public bool isRevolution = false; // 공전 여부를 확인하는 논리타입

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime); // 자신이 회전하는 기능
        if (isRevolution) // 공전 여부를 확인
        {
            transform.RotateAround(targetPlanet.position, Vector3.up, RevolutionSpeed * Time.deltaTime); // 타겟 행성을 공전하는 기능
        }
    }
}
