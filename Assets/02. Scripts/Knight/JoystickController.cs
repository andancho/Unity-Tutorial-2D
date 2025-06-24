using Microsoft.Win32.SafeHandles;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] KnightController_Joystick knightController; //KnightController_Joystick 스크립트 참조

    [SerializeField] GameObject backgroundUI;
    [SerializeField] GameObject handlerUI;

    Vector2 startPos, curPos;

    void Start()
    {
        backgroundUI.SetActive(false);
    }
    public void OnPointerDown(PointerEventData eventData)   //마우스 누를 때 호출
    {
        backgroundUI.transform.position = eventData.position;
        handlerUI.transform.position = eventData.position;
        backgroundUI.SetActive(true);
        startPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)  //마우스 누르고 있을 때 지속적으로 호출
    {
        curPos = eventData.position;
        Vector2 dragDir = curPos - startPos; //드래그 방향

        float maxDist = Mathf.Min(dragDir.magnitude, 100f); //dragDir와 100f 중 작은값을 maxDist에 할당

        //normalized는 벡터의 방향을 유지하면서 크기를 1로 만듭니다.
        handlerUI.transform.position = startPos + dragDir.normalized * maxDist; //방향벡터dragDir에 크기벡터maxDist를 곱해서 핸들 위치 설정

        knightController.InputJoystick(dragDir.x, dragDir.y); //KnightController_Joystick 스크립트의 InputJoystick 메서드 호출하여 x,y값 전달
    }



    public void OnPointerUp(PointerEventData eventData) //마우스 뗄 때 호출
    {
        knightController.InputJoystick(0, 0);
        handlerUI.transform.localPosition = Vector2.zero; //핸들 위치 초기화
        backgroundUI.SetActive(false);
    }
}
