using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            StudyLog.coinCount++; // Increment the coin count in StudyLog
            Debug.Log($"현재 코인 : {StudyLog.coinCount}!");
            Destroy(gameObject); // Destroy the coin after collection
        }
    }
}

