using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ReMoteController : MonoBehaviour
{
    public GameObject videoScreen;
    public Button[] buttonUI;
    private VideoPlayer videoPlayer;
    public VideoClip[] videoClips;

    public int curClipIndex;

    public bool isOn;
    public bool isMute;

    public void Awake()
    {
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();
        videoPlayer.clip = videoClips[0];
    }

    public void Start()
    {
        buttonUI[0].onClick.AddListener(OnScreenPower);
        buttonUI[1].onClick.AddListener(OnMute);
        
    }

    public void OnChangeChannel(string buttonName)
    {
        
        if (buttonName == "Next")
        {
            curClipIndex++;
            if (curClipIndex > 2) curClipIndex = 0;

        }
        else
        {
            curClipIndex--;
            if (curClipIndex < 0) curClipIndex = 2;
            
        }

        videoPlayer.clip = videoClips[curClipIndex];
    }

    public void PrevChannel()
    {

    }


    public void OnScreenPower()
    {
        if (!isOn)
        {
            isOn = true;
            videoScreen.SetActive(true);
        }
        else
        {
            isOn = false;
            videoScreen.SetActive(false);
        }

    }

    public void OnMute()
    {
        isMute = !isMute;
        videoPlayer.SetDirectAudioMute(0, isMute);

    }


}
