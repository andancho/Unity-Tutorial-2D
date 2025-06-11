using UnityEngine;
using System.Collections;
public class StudyCoroutine : MonoBehaviour
{
    private bool isStop = false;

    void Start()
    {
        StartCoroutine(BombRoutine());
    }

    IEnumerator BombRoutine()
    {
        int t = 10;
        while (t > 0)
        {
            Debug.Log($"{t}초 남았습니다.");
            yield return new WaitForSeconds(1f);
            t--;

            if (isStop)
            {
                Debug.Log("폭탄이 해제되었습니다.");
                yield break;
            }
        }

        Debug.Log("폭탄이 터졌습니다.");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStop = true;
        }
    }

    //IEnumerator Start() // Start 메서드도 코루틴으로 만들 수 있다.
    //{
    //    while(true) // 무한 루프
    //    {
    //        yield return new WaitForSeconds(3f); // 시간 조절이 가능한 보조Update를 구현할 수 있다.
            
    //    }
        
    //}

    //private void Start()
    //{
    //    StartCoroutine("RoutineA"); // StopCoroutine("RoutineA");로 정지 가능
    //    StartCoroutine(RoutineB()); // StopCoroutine(RoutineB());로 정지 불가(정지하려면 변수로 저장해야 함)

    //    // StopCoroutine("RoutineA"); // 코루틴 정지 (이름으로 정지)

    //    // runnigCoroutine = StartCoroutine(RoutineB()); // 코루틴을 변수에 저장(정지를 위한 변수 사용)
    //    // StopCoroutine(RoutineB(runnigCoroutine); // 코루틴 정지 (함수로 정지, 변수로 저장해야 함)

    //    // StopAllCoroutines(); // 모든 코루틴 정지


    //}

    IEnumerator RoutineA()   // 코루틴은 대기를 할 수 있는 기능
    {
        yield return new WaitForSeconds(3f); // 3초 대기

        Debug.Log("코루틴A");
    }

    IEnumerator RoutineB()   // 코루틴은 대기를 할 수 있는 기능
    {
        yield return new WaitForSeconds(3f); // 3초 대기

        Debug.Log("코루틴B");
    }

}
