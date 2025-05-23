using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StudyArray : MonoBehaviour
{

    //public int[] arrayNumbers = new int[5] {1,2,3,4,5}; // 5개의 정수형 배열을 선언

    List<string> listJob = new List<string>(); // List를 사용하기 위해 using System.Collections.Generic;를 추가해야 함

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log($"Array의 첫 번째 값   : {arrayNumbers[0]}");
        //Debug.Log($"Array의 세 번째 값 : {arrayNumbers[2]}");
        //Debug.Log($"Array의 여섯 번째 값 : {arrayNumbers[5]}");

        listJob.Add("전사");
        listJob.Add("마법사");
        listJob.Add("도적");
        listJob.Add("사제");
        listJob.Add("주인공");

        

        Debug.Log($"총 List의 데이터 수   : {listJob.Count}");
        Debug.Log($"List의 첫 번째 값   : {listJob[0]}");
        Debug.Log($"List의 다섯 번째 값 : {listJob[4]}");      //0부터 시작하기 때문에 0번쨰 인덱스는 5번째 값
        Debug.Log($"List의 마지막 값 : {listJob[listJob.Count - 1]}");   //Count는 1부터 시작하기 때문에 -1을 해줘야 마지막 인덱스가 나옴
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
