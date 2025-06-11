using UnityEngine;

public class StudyForeach : MonoBehaviour
{
    public string[] persons = new string[5] { "Alice", "Bob", "Charlie", "David", "Eve" };
    void Start()
    {
        foreach (string person in persons) // foreach 문을 사용하여 배열의 각 요소를 순회합니다.
        {
            Debug.Log($"Person: {person}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
