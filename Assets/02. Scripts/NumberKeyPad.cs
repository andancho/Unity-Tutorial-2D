using TMPro;
using UnityEngine;
using UnityEngine.UI; // UI 컴포넌트 사용을 위해 추가

public class NumberKeyPad : MonoBehaviour
{
    public TextMeshProUGUI[] window;

    public string password; // 비밀번호를 저장할 변수
    public string keyPadNumber; // 입력한 숫자

    public string[] windowPassword; // 각 창의 비밀번호를 저장할 배열
    public string[] curPadNumber; // 현재 입력된 숫자를 저장할 배열
    public string defaultPadNumber = "-"; // 기본 입력 숫자

    public bool[] isPass;
    public bool allPass = false; // 모든 창의 비밀번호가 일치하는지 여부

    public GameObject doorLock; // 잠긴 문 오브젝트

    public Animator doorAnim; // 애니메이터 컴포넌트

    public bool passCheakNumber = false; // 비밀번호 확인 여부


    //public void OnInputNumber(string numString) //숫자 패드 누르면 실행
    //{
    //    keyPadNumber += numString; // 입력한 숫자를 keyPadNumber에 추가
    //    Debug.Log($"{numString}입력. 현재 입력 : {keyPadNumber}"); // 디버그 로그로 입력한 숫자 확인
    //}

    private void Start()
    {
        windowPassword[0] = Random.Range(0,10).ToString();
        windowPassword[1] = Random.Range(0, 10).ToString();
        windowPassword[2] = Random.Range(0, 10).ToString();
        windowPassword[3] = Random.Range(0, 10).ToString();
    }

    public void OnCheakNumber()
    {
        isPass = new bool[4]; // isPass 배열 초기화
        for (int i = 0; i < 4; i++ )
        {
            if (i >= 4) // 배열의 범위를 벗어나지 않도록 체크
            {
                Debug.LogError("배열 범위 초과!"); // 오류 로그 출력
                break; // 함수 종료
            }
            if (window[i].text == windowPassword[i]) // 현재 입력된 숫자를 비밀번호 배열의 해당 인덱스와 비교
            {
                isPass[i] = true;
            }
        }

        if (isPass[0] == true)
        {
            if(isPass[1] == true)
            {
                if (isPass[2] == true)
                {
                    if (isPass[3] == true)
                    {
                        allPass = true; // 모든 창의 비밀번호가 일치하면 allPass를 true로 설정
                    }
                }
            }
        }

        if (allPass == true) // 입력한 숫자가 비밀번호와 일치하는지 확인
        {
            Debug.Log("비밀번호 일치!"); // 일치하면 로그 출력
            
            doorAnim.SetTrigger("Door Open");
            doorLock.SetActive(false);
            
        }
        else
        {
            Debug.Log("비밀번호 불일치!"); // 불일치하면 로그 출력
            window[0].text = defaultPadNumber;
            window[1].text = defaultPadNumber;
            window[2].text = defaultPadNumber;
            window[3].text = defaultPadNumber;
        }
    }

    public void OnDeletNumber()
    {
        if (keyPadNumber.Length > 0) // 입력된 숫자가 있을 때만 실행
        {
            keyPadNumber = keyPadNumber.Substring(0, keyPadNumber.Length - 1); // 마지막 숫자 제거
            Debug.Log($"숫자 제거. 현재 입력 : {keyPadNumber}"); // 디버그 로그로 현재 입력 확인
        }
    }

    public void OnClickPad(string gainNumber)
    {
        if (window[3].text == "-")
        {
            if (window[2].text == "-")
            {
                if (window[1].text == "-")
                {
                    if (window[0].text == "-")
                    {
                        window[0].text = gainNumber;
                        return;
                    }
                    window[1].text = gainNumber;
                    return;
                }
                window[2].text = gainNumber;
                return;
            }
            window[3].text = gainNumber;
            return;
        }
        
    }

    public void OnDeletPad()
    {
        if (window[3].text != "-")
        {
            window[3].text = "-";
            return;
        }
        if (window[2].text != "-")
        {
            window[2].text = "-";
            return;
        }
        if (window[1].text != "-")
        {
            window[1].text = "-";
            return;
        }
        if (window[0].text != "-")
        {
            window[0].text = "-";
            return;
        }
    }
}
