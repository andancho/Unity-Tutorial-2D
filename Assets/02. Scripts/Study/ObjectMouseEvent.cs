using UnityEngine;

public class ObjectMouseEvent : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Mouse down");
    }
    private void OnMouseEnter()
    {
        Debug.Log("Mouse enter");
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse exit");
    }

    private void OnMouseUp()
    {
        Debug.Log("Mouse up");
    }

}
