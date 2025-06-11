using UnityEngine;


namespace Cat_Game  //타 게임 프로젝트와 혼용,충돌을 방지하기 위해 네임스페이스 설정
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource audioSource; // 오디오 소스 컴포넌트
        public AudioClip bgmClip;
        public AudioClip jumpClip; // 점프 사운드
        public AudioClip introBgmClip; // 인트로 사운드
        public AudioClip colliderClip; // 충돌 사운드


        public void SetBGMSound(string bgmName)
        {
            if (bgmName == "Intro")
                audioSource.clip = introBgmClip; // 인트로 사운드 설정
            else if (bgmName == "Play")
                audioSource.clip = bgmClip; // BGM 사운드 설정


            audioSource.loop = true; // BGM이 반복 재생되도록 설정
            audioSource.volume = 0.15f; // BGM 볼륨 설정 (0.0f ~ 1.0f 범위)

            audioSource.Play(); // BGM 재생

            //audioSource.Stop(); // BGM 정지 (필요시 사용)
            //audioSource.Pause(); // BGM 일시 정지 (필요시 사용)
        }

        public void StopBgm()
        {
            audioSource.Stop(); // BGM 정지
        }
        public void OnJumpSound()
        {
            audioSource.PlayOneShot(jumpClip); // 이벤트 사운드(정지 및 설정 조절 불가) 재생
        }

        public void OnColliderSound()
        {
            audioSource.PlayOneShot(colliderClip); // 이벤트 사운드(정지 및 설정 조절 불가) 재생
        }
    }
}

