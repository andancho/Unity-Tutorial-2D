using UnityEngine;

public class StudyProferty : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 20; // SerializeField를 사용하여 private 변수도 Unity 에디터에서 보이도록 함

    private int number1 = 10;
    public int Number1
    {
        get { return number1; }     // 외부에서 접근할 수 있도록 프로퍼티를 사용하여 값을 가져옴
        set { number1 = value; }    // 외부에서 수정할 수 있도록 프로퍼티를 사용하여 값을 설정
    }

    public int Number2 { get; set; } = 20;

    public int Number3 { get; private set; } = 30; // 외부에서 읽기만 가능하고, 내부에서만 수정할 수 있는 프로퍼티

}
