using UnityEngine;

public class Material_LoopMap : MonoBehaviour
{
    public MeshRenderer renderer;
    public float offsetSpeed = 0.1f; // 텍스처 오프셋 속도


    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = Vector2.right * offsetSpeed * Time.deltaTime; // 변경할 오프셋 값

        renderer.material.SetTextureOffset("_MainTex", renderer.material.GetTextureOffset("_MainTex") + offset); // Texture의 Offset을 적용
    }
}
