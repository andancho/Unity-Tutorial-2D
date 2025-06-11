using UnityEngine;

public class WhileLoop : MonoBehaviour
{
    int count = 0;
    void Start()
    {

        while (count <= 10)
        {
            count++;
            if (count % 3 == 0)   // count를 3으로 나눈 나머지가 0이면, 즉 3의 배수일 때
            {
                Debug.Log("박수");
                continue; // continue는 현재 반복을 건너뛰고 다음 반복으로 넘어갑니다.
            }
            Debug.Log(count);
        }
    }


}
