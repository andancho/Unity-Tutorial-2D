using UnityEngine;

public class MathLerp : MonoBehaviour
{
    public Vector3 targetPos;
    public float smoothValue;   //이동 비율0~1(0.1이면 10%)

    Vector3 startPos;
    float timer, percent;
    public float lerpTime;

    private void Start()
    {
        startPos = transform.position; // 시작 위치를 현재 위치로 설정
    }

    private void Update()
    {
        timer += Time.deltaTime;
        percent = timer / lerpTime; // 0~1 사이의 비율 계산(lerpTime은 마지막 지점까지 가는 총 시간)

        // 현재 위치, 타겟 위치,  퍼센트값(시간이 지나며 증가하기 때문에 부드러운 움직임)
        transform.position = Vector3.Lerp(startPos, targetPos, percent);
    }
}
