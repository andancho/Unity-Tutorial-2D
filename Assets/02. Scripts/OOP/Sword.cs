using UnityEngine;

public class Sword : MonoBehaviour
{
    float Damage = 10f;

    public void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (other.GetComponent<IDamageable>() != null)
        {
            damageable.TakeDamage(Damage);
            Debug.Log($"{other.name}에게 {Damage}의 피해를 입혔습니다.");
        }
    }
}
