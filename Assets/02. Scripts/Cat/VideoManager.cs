using UnityEngine;
using UnityEngine.Video;

namespace Cat_Game
{
    public class VideoManager : MonoBehaviour
    {
        public GameObject videoPanel;

        public VideoPlayer vPlayer;
        public VideoClip[] vClip;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            vPlayer = GetComponent<VideoPlayer>();
        }

        public void VideoPlay(bool isHappy)
        {
            videoPanel.SetActive(true);

            var endingClip = isHappy ? vClip[0] : vClip[1];
            vPlayer.clip = endingClip;
            vPlayer.Play();
        }
    }

}
