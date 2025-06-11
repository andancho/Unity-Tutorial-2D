using UnityEngine;

public class StudyRandom : MonoBehaviour
{
    private void OnEnable()
    {
        //int randomNumber = Random.Range(0, 100); // 0부터 99까지의 랜덤 숫자 생성(최대수치 미포함)
        float rnaNumber = Random.Range(0f, 100f); // 0f부터 100f까지의 랜덤 숫자 생성(최대수치 포함)


        Debug.Log(rnaNumber);
    }
}
