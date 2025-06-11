using UnityEngine;

public class StudyInvoke : MonoBehaviour
{
    public int timer;
    void Start()
    {


        Invoke("Method", timer); // timer초 후에 Method() 호출

        CancelInvoke("Method"); // Method() 호출 취소

        InvokeRepeating("Method", 2f, 1f); // 2초 후에 Method()를 호출하고, 이후 1초마다 반복 호출
    }

    void Method()
    {
        Debug.Log("Invoke Method Called");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke("Method"); // Space 키를 누르면 Method() 호출 취소
            Debug.Log("Invoke Method Cancelled");
        }
    }
}
