using UnityEngine;

public class WindowColor : MonoBehaviour
{
    public NumberKeyPad keyPad;
    public Renderer windowRenderer; // Renderer를 추가하여 색상을 변경할 수 있도록 설정

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Renderer 컴포넌트를 가져옴
        windowRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (keyPad.window[0].text != keyPad.windowPassword[0])
        {
            // Renderer의 material.color를 사용하여 색상을 변경
            windowRenderer.material.color = Color.red; // 0번 창이 비밀번호와 다르면 빨간색
        }
        if (keyPad.window[1].text != keyPad.windowPassword[1])
        {
            windowRenderer.material.color = Color.red; // 1번 창이 비밀번호와 다르면 빨간색
        }
        if (keyPad.window[2].text != keyPad.windowPassword[2])
        {
            windowRenderer.material.color = Color.red; // 2번 창이 비밀번호와 다르면 빨간색
        }
        if (keyPad.window[3].text != keyPad.windowPassword[3])
        {
            windowRenderer.material.color = Color.red; // 3번 창이 비밀번호와 다르면 빨간색
        }

        if (keyPad.allPass == true)
        {
            // 모든 창의 비밀번호가 일치하면 초록색으로 변경
            windowRenderer.material.color = Color.green;
        }
    }
}
