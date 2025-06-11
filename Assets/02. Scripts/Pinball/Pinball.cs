using System;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    public Bar_Controller pinballManager; // À¯´ÏÆ¼ »ó¿¡¼­ ÇÒ´ç ÇÊ¿ä

    private void OnCollisionEnter2D(Collision2D other)
    {
        int score = 0;
        switch (other.gameObject.tag)
        {
            case "Score10":
                score = 10;
                break;
            case "Score20":
                score = 20;
                break;
            case "Score50":
                score = 50;
                break;
        }

        pinballManager.totalScore += score;
        Debug.Log($"{score}Á¡ È¹µæ");

    }




    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Score10"))
    //    {
    //        pinballManager.totalScore += 10;

    //        Debug.Log("10Á¡ È¹µæ");
    //    }
    //    else if (other.gameObject.CompareTag("Score20"))
    //    {
    //        pinballManager.totalScore += 20;

    //        Debug.Log("20Á¡ È¹µæ");
    //    }
    //    else if (other.gameObject.CompareTag("Score50"))
    //    {
    //        pinballManager.totalScore += 50;

    //        Debug.Log("50Á¡ È¹µæ");
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            Debug.Log($"°ÔÀÓ Á¾·á : ÇöÀç Á¡¼ö {pinballManager.totalScore}");
        }
    }
}