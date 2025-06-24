using NUnit.Framework;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class LottoGenerator : MonoBehaviour
{
    //public int[] intArray = new int[45];
    public List<int> intList = new List<int>(); //필요할 때 마다 추가/삭제/삽입 가능한 방식


    int ShakeCount = 1000;

    private void Awake()
    {
        for (int i = 1; i < 46; i++)
        {
            intList.Add(i); // 1부터 45까지의 숫자를 리스트에 추가
        }
    }
    IEnumerator Start()
    {
        for (int i = 0; i < ShakeCount; i++)
        {
            int ranInt1 = Random.Range(0, intList.Count);
            int ranInt2 = Random.Range(0, intList.Count);

            var temp = intList[ranInt1];
            intList[ranInt1] = intList[ranInt2];
            intList[ranInt2] = temp;

            yield return null;

        }

        List<int> resultGroup = new List<int>();

        for (int i = 0; i < 6; i++)
            resultGroup.Add(intList[i]); // 리스트에서 6개의 숫자를 선택

        resultGroup.Sort(); // 정렬

        string resultNumber = $"이번 주 로또 번호 : {resultGroup[0]} / {resultGroup[1]} / {resultGroup[2]} / {resultGroup[3]} / {resultGroup[4]} / {resultGroup[5]} / 보너스 넘버 : {intList[6]}";

        Debug.Log(resultNumber); // 로또 번호 출력
    }
}