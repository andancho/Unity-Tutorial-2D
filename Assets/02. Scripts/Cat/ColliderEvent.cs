using Cat_Game;
using System;
using UnityEngine;

public class ColliderEvent : MonoBehaviour
{
    public GameObject playObj;
    public SoundManager soundManager; // 사운드 매니저를 참조하기 위한 변수
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            
            soundManager.audioSource.Stop();// BGM 정지

            Invoke("SetAct", 3f); // 플레이 오브젝트 비활성화
        }
    }

    void SetAct()
    {
        playObj.SetActive(false);
    }
}