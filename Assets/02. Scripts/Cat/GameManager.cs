using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
namespace Cat_Game
{

    public class GameManager : MonoBehaviour
    {
        public TextMeshProUGUI playTimeUI;
        private static float timer;
        public TextMeshProUGUI scoreUI;
        public GameObject scoreImg;

        public SoundManager soundManager; // 사운드 매니저를 참조하기 위한 변수

        public static bool isPlay = false; // 게임이 진행 중인지 여부
        public static int score; //점수 변수
        private void Start()
        {
            soundManager.SetBGMSound("Intro");
        }

        private void Update()
        {
            if (!isPlay) return;
            timer += Time.deltaTime;

            playTimeUI.text = string.Format("플레이 시간: {0:F0}초", timer);

            scoreUI.text = score.ToString($"X {score}"); //점수 표시

        }
        public static void ResetPlayUI()
        {
            timer = 0f;
            score = 0;
        }
    }
}
