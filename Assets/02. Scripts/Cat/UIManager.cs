using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Cat_Game
{
    public class UIManager : MonoBehaviour
    {
        public GameObject playObj;
        public GameObject introUI;
        public GameObject playUI;

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;
        public GameManager gameManager;
        public SoundManager soundManager; // 사운드 매니저

        public Button startButton;
        public Button reStartButton;
        void Awake()
        {
            playObj.SetActive(false);
            introUI.SetActive(true);
            playUI.SetActive(false);
        }

        void Start()
        {
            startButton.onClick.AddListener(OnStartButton);
            reStartButton.onClick.AddListener(OnRestartButton);
        }

        public void OnRestartButton()
        {
            GameManager.ResetPlayUI();
            playObj.SetActive(true);
        }
        public void OnStartButton()
        {
            nameTextUI.text = inputField.text;
            bool isNameDefalt = string.IsNullOrEmpty(nameTextUI.text) || nameTextUI.text == "";
            if (isNameDefalt == true)
            {
                nameTextUI.text = "고냥이";
            }

            GameManager.isPlay = true; // 게임 시작
            gameManager.playTimeUI.gameObject.SetActive(true); // 플레이 시간 UI 활성화
            gameManager.scoreImg.SetActive(true); // 점수 이미지 활성화

            playObj.SetActive(true);
            playUI.SetActive(true);
            introUI.SetActive(false);

            GameManager.isPlay = true; // 게임이 시작됨을 알림
            soundManager.SetBGMSound("Play"); // 게임 플레이 BGM 설정
        }




    }
}
