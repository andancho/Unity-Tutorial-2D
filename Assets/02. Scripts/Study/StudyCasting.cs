using UnityEngine;

public class StudyCasting : MonoBehaviour
{
    int num1 = 1;
    float num2 = 2.9f;


    void Start()
    {
        num1 += (int)num2; // float to int casting
        Mathf.Floor(num2); //소수점 내림
        Mathf.Ceil(num2); //소수점 올림
        Mathf.Round(num2); //반올림
        Debug.Log(num1);

        float num4 = Mathf.Floor(num2);
        float num5 = Mathf.Ceil(num2);
        float num6 = Mathf.Round(num2);

        Debug.Log($"Floor 내림{num4}");
        Debug.Log($"Ceil 올림{num5}");
        Debug.Log($"Round 반올림{num6}");
    }
}
