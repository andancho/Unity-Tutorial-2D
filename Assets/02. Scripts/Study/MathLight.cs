using UnityEngine;

public class MathLight : MonoBehaviour
{
    private Light light;
    private float theta;
    [SerializeField] float power;
    [SerializeField] float speed;

    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        theta += Time.deltaTime * speed;

        //light.intensity = Mathf.Cos(theta) * power; //삼각 함수 그래프

        light.intensity = Mathf.PerlinNoise(theta, 0) * power;  //유명한 펄린 노이즈 그래프로 불규칙적인 깜빡임 효과 연출(실제로는 규칙성이 있음)
    }
}
