using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    public enum ColliderType { Pipe, Apple, Both }
    public ColliderType colliderType;

    public float moveSpeed = 3f;
    public float returnPosX = 11f;
    public float randomPosY;

    public GameObject pipe;
    public GameObject apple;
    public GameObject particle;

    Vector3 initPos;
    private void Awake()
    {
        initPos = transform.position;
    }

    private void Start()
    {
        SetRandomSetting(transform.position.x);
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= -returnPosX)
        {
            SetRandomSetting(returnPosX);
        }
    }

    void SetRandomSetting(float posX)
    {
        randomPosY = Random.Range(-8.5f, -6f);
        transform.position = new Vector3(posX, randomPosY, 0);

        pipe.SetActive(false);
        apple.SetActive(false);
        particle.SetActive(false);

        colliderType = (ColliderType)Random.Range(0, 3);

        switch (colliderType)
        {
            case ColliderType.Pipe:
                pipe.SetActive(true);
                break;
            case ColliderType.Apple:
                apple.SetActive(true);
                break;
            case ColliderType.Both:
                pipe.SetActive(true);
                apple.SetActive(true);
                break;
        }
    }
}
