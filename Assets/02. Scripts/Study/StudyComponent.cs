using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    public GameObject obj;

    public Mesh msh;
    public Material mat;

    void Start()
    {
        CreatCube("Cube");
    }

    public void CreatCube(string name)
    {
 
        obj = new GameObject(name);

        obj.AddComponent<MeshFilter>();
        obj.GetComponent<MeshFilter>().mesh = msh;

        obj.AddComponent<MeshRenderer>();
        obj.GetComponent<MeshRenderer>().material = mat;

        obj.AddComponent<BoxCollider>();

    }
}