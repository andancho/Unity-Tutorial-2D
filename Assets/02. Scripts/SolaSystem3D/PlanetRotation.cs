using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public Transform targetPlanet; // Ÿ�� �༺

    public float rotSpeed = 5f;  // ���� �ӵ�
    public float RevolutionSpeed = 1f; // ���� �ӵ�

    public bool isRevolution = false; // ���� ���θ� Ȯ���ϴ� ��Ÿ��

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime); // �ڽ��� ȸ���ϴ� ���
        if (isRevolution) // ���� ���θ� Ȯ��
        {
            transform.RotateAround(targetPlanet.position, Vector3.up, RevolutionSpeed * Time.deltaTime); // Ÿ�� �༺�� �����ϴ� ���
        }
    }
}
