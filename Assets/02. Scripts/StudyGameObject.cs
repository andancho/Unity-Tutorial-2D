using System;
using UnityEngine;

public class StudyGameObject : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        CreateAmongus();
    }

    public void CreateAmongus()
    {
        GameObject obj = Instantiate(prefab);
        obj.name = "어몽어스 캐릭터";

        Transform objTf = obj.transform;
        int count = objTf.childCount;

        Debug.Log($"캐릭터의 자식 오브젝트 수 : {objTf.GetChild(count)}");

        Debug.Log($"캐릭터의 첫번째 자식 오브젝트 : {objTf.GetChild(0).name}");
        Debug.Log($"캐릭터의 마지막 자식 오브젝트 : {objTf.GetChild(count-1).name}");


    }
}