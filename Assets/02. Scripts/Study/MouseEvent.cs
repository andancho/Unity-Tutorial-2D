using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) // 0: 왼쪽 버튼, 1: 오른쪽 버튼, 2: 가운데 버튼
        {
            Debug.Log("Mouse Button Down");
        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse Button");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse Button Up");
        }

    }
    
    void MosueClickEvent()
    {

    }
}
