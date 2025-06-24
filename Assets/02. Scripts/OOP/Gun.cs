using UnityEngine;

public class Gun : MonoBehaviour, IDropItem
{
    public GameObject bulletPrefab; // 총알 프리팹
    public Transform firePos; // 총알이 발사될 위치
    public void Grab(Transform grabPos)
    {
        transform.SetParent(grabPos); // 캐릭터 위치를 따라오도록 자식으로 설정
        transform.localPosition = Vector3.zero; // 손 위치로 총을 이동
        transform.localRotation = Quaternion.identity; 
        Debug.Log("총을 주웠다.");
    }

    public void Use()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePos.position, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        bulletRb.AddForce(firePos.forward * 100f, ForceMode.Impulse); // 총알을 앞으로 발사
        Debug.Log("총을 발사한다.");
    }

    public void Drop()
    {
        transform.SetParent(null); // 부모를 제거하여 월드 공간으로 이동
        transform.position = Vector3.zero; // 손전등을 원래 위치로 이동
        Debug.Log("총을 버렸다.");
    }
}