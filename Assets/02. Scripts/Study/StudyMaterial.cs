using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class StudyMaterial : MonoBehaviour
{
    

    public string hexCode;
    void Start()
    {
        //GetComponent<Material>() = mat; //Material을 바꾸는 방식X

        //GetComponent<MeshRenderer>().sharedMaterial = mat; // Renderer 컴포넌트의 material 속성에 mat을 할당

        //GetComponent<MeshRenderer>().material.color = Color.green;

        //GetComponent<MeshRenderer>().sharedMaterial.color = Color.blue;   //sharedMaterial은 할당된 마테리얼 자체의 값이 바뀌기 때문에 런타임 종료 후에도 변경된 값이 유지되므로 사용에 주의

        //GetComponent<MeshRenderer>().material.color = new Color(0/255f, 0/255f, 0/255f, 255/255f); // 새로운 색상으로 변경 (R, G, B, A), 입력값은 0~1로, 255f로 나누어야 함

        Material mat = GetComponent<MeshRenderer>().material; // 현재 MeshRenderer의 material을 가져와 mat에 할당
        Color outputColor;

        if (ColorUtility.TryParseHtmlString(hexCode, out outputColor)) // hexCode를 Color로 변환
        {
            mat.color = outputColor; // 변환된 색상을 material의 색상으로 설정
        }
        else
        {
            Debug.LogError("Invalid hex code: " + hexCode); // hexCode가 유효하지 않은 경우 에러 로그 출력
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
