using UnityEngine;

public class Calculator : MonoBehaviour
{
    public int number1, number2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int addresult = AddMethod();

        int minusresult = MinusMethod();

        Debug.Log($"ÇÕÄ£ °ª : {addresult} / »« °ª : {minusresult}");


    }

    int AddMethod()
    {
        int result = number1 + number2;

        return result;
    }

    int MinusMethod()
    {
        int result = number1 - number2;

        return result;
    }


    // Update is called once per frame
    void Update()
    {

    }
}