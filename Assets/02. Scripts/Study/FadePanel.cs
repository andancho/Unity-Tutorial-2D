using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    public Image fadePanel;
    public bool isFadeout = false;

    public void OnFade(float fadeTime, Color color)
    {
        StartCoroutine(FadeRoutine(fadeTime, color)); // 페이드 루틴 시작
    }

    

    IEnumerator FadeRoutine(float fadeTime, Color color)
    {
        float timer = 0f;
        float percent = 0f; // 초기 퍼센트 값
        
        while (percent <= 1)
        {
            timer += Time.deltaTime; // 타이머 증가
            percent = timer / fadeTime; // 퍼센트 계산
            

            fadePanel.color = new Color(color.r, color.g, color.b, percent); // 초기 투명도 설정 (검은색)
            yield return null;
        }
        
    }
}
