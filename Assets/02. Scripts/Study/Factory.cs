using UnityEngine;

public class Factory<T> : MonoBehaviour
{
    public T prefab;
    public Factory()
    {
        Debug.Log($"Factory는 {typeof(T)} 입니다");
    }
}
