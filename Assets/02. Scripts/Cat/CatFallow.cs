using UnityEngine;
using Cat_Game;

public class CatFallow : MonoBehaviour
{
    public Cat_Controller catController;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = catController.transform.position; // 고양이의 위치를 따라감
    }
}
