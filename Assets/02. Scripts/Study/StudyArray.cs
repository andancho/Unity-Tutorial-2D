using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StudyArray : MonoBehaviour
{

    //public int[] arrayNumbers = new int[5] {1,2,3,4,5}; // 5���� ������ �迭�� ����

    List<string> listJob = new List<string>(); // List�� ����ϱ� ���� using System.Collections.Generic;�� �߰��ؾ� ��

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log($"Array�� ù ��° ��   : {arrayNumbers[0]}");
        //Debug.Log($"Array�� �� ��° �� : {arrayNumbers[2]}");
        //Debug.Log($"Array�� ���� ��° �� : {arrayNumbers[5]}");

        listJob.Add("����");
        listJob.Add("������");
        listJob.Add("����");
        listJob.Add("����");
        listJob.Add("���ΰ�");

        

        Debug.Log($"�� List�� ������ ��   : {listJob.Count}");
        Debug.Log($"List�� ù ��° ��   : {listJob[0]}");
        Debug.Log($"List�� �ټ� ��° �� : {listJob[4]}");      //0���� �����ϱ� ������ 0���� �ε����� 5��° ��
        Debug.Log($"List�� ������ �� : {listJob[listJob.Count - 1]}");   //Count�� 1���� �����ϱ� ������ -1�� ����� ������ �ε����� ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
