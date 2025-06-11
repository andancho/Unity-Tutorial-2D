using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float returnPosX = 11f;
    public float randomPosY;

    private void Start()
    {
        // 초기 위치 설정
        randomPosY = Random.Range(-8.5f, -10f);
        transform.position = new Vector3(this.gameObject.transform.position.x, randomPosY, 0);
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= -returnPosX)
        {
            randomPosY = Random.Range(-8.5f, -10f);

            transform.position = new Vector3(returnPosX, randomPosY, 0);
        }
    }
}