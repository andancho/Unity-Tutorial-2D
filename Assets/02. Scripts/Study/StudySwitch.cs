using UnityEngine;

public class StudySwitch : MonoBehaviour
{
    public enum CalculationType { Plus, Minus, Multiply, Divide }   //열거형 생성
    public CalculationType calculationType; //열거형 변수 생성

    public int input1, input2, result; //입력값과 결과값 변수 생성

    void Start()
    {
        Calculation(); //시작할 때 계산 함수 호출
        Debug.Log($"계산 결과 : {Calculation()}");
    }

    int Calculation()
    {
        

        switch (calculationType)
        {
            case CalculationType.Plus:
                result = input1 + input2; //입력값을 더하기
                break;
            case CalculationType.Minus:
                result = input1 - input2; //입력값을 빼기
                break;
            case CalculationType.Multiply:
                result = input1 * input2; //입력값을 곱하기
                break;
            case CalculationType.Divide:
                result = input1 / input2; //입력값을 나누기
                break;
        }

        return result;
    }

}
