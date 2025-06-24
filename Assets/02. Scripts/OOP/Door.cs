using UnityEngine;

public class Door : MonoBehaviour, IDamageable
{
    public float hp;
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Debug.Log("문이 파괴되었습니다.");
    }

}
