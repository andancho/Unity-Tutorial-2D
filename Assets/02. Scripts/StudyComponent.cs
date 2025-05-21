using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    public GameObject obj;

    public string changeName;

    private void Start()
    {
        obj = GameObject.Find("Cube");

        changeName = "NewName";
        obj.name = changeName;
        
    }

}
