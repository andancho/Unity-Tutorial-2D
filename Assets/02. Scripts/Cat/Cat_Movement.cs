using UnityEngine;

public class Cat_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");
        float jump = Input.GetAxisRaw("Jump");

        Vector3 dir = new Vector3(h, 0, 0);
        Vector3 normalDir = dir.normalized; // 정규화 과정 (0 ~ 1)

        Vector3 jumpDir = new Vector3(0, jump, 0);
        if (jumpDir.y > 0)
        {
            // 점프 로직을 여기에 추가할 수 있습니다.
            Debug.Log("점프!");
        }

        this.transform.position += normalDir * moveSpeed * Time.deltaTime;



    }
}
