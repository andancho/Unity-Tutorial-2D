using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreUI; //표시용 UI 텍스트 컴포넌트
    public int score; //점수 변수

    private void Update()
    {
        scoreUI.text = score.ToString($"X {score}"); //점수 표시
    }


}
