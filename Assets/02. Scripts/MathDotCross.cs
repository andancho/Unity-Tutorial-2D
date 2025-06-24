using UnityEngine;

public class MathDotCross : MonoBehaviour
{
    public Vector3 vecA = new Vector3(1, 0, 0);
    public Vector3 vecB = new Vector3(0, 1, 0);

    private void Start()
    {
        //float dotResult = Vector3.Dot(vecA, vecB);   //끼인각 Cos(theta)의 값
        float dotResult = Vector3.Angle(vecA, vecB); // 두 벡터 사이의 각도

        Vector3 crossResult = Vector3.Cross(vecA, vecB); // 두 벡터의 외적

        Debug.Log($"벡터의 내적 : {dotResult}");
        Debug.Log($"벡터의 외적 : {crossResult}");
    }
}
