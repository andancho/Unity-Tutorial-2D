using UnityEngine;

public class FlashLight : MonoBehaviour, IDropItem
{
    public GameObject lightObj;

    public void Grab(Transform grabPos)
    {
        transform.SetParent(grabPos); // 캐릭터 위치를 따라오도록 자식으로 설정
        transform.localPosition = Vector3.zero; // 손 위치로 총을 이동
        transform.localRotation = Quaternion.identity; // 손 위치로 총을 이동
        Debug.Log("손전등을 주웠다.");
    }

    public void Use()
    {
        lightObj.SetActive(!lightObj.activeSelf); // 라이트 상태에 따라 반대로 전환(스위치)
        if (lightObj.activeSelf)
            Debug.Log("라이트를 켰다.");
        else
            Debug.Log("라이트를 껐다.");
    }

    public void Drop()
    {
        transform.SetParent(null); // 부모를 제거하여 월드 공간으로 이동
        transform.position = Vector3.zero; // 손전등을 원래 위치로 이동

        Debug.Log("손전등을 버렸다.");
    }

   
}