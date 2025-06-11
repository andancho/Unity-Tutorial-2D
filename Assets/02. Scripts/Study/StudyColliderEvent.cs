using UnityEngine;

public class StudyColliderEvent : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision Enter");
    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ãæµ¹!");
    }
}