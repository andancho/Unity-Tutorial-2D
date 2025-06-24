using UnityEngine;

public class ExternalClass : MonoBehaviour
{
    public StudyProferty studyProferty;
    private void Start()
    {
        int num1 = studyProferty.Number1;

        studyProferty.Number1 = 100;

        
    }
}
