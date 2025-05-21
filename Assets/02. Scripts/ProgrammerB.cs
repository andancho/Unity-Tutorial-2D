using UnityEngine;


public class ProgrammerB : MonoBehaviour
{
    [SerializeField] ProgrammerA pA;
    

    private void Start()
    {
        

        pA.number2 = 10;

        Debug.Log($"number2 : {pA.number2}");
    }
}
