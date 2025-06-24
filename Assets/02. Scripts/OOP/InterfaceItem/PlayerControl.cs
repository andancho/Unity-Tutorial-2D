using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 3f;
    private IDropItem currentItem;
    public Transform grabPos;
    

    void Update()
    {
        Move();
        Interaction();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v).normalized;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    private void Interaction()
    {
        if (currentItem == null) return; //아이템이 없으면 아무것도 하지 않음
        if (Input.GetMouseButtonDown(0))
        {
            currentItem.Use();  //아이템 사용하기
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentItem.Drop(); //아이템 버리기
            currentItem = null; //아이템을 비우기
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDropItem>() != null)
        {
            var item = other.GetComponent<IDropItem>();
            currentItem = item;

            currentItem.Grab(grabPos); //아이템 줍기
        }
    }
}
