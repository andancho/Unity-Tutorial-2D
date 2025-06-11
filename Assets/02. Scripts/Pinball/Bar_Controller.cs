using UnityEngine;

public class Bar_Controller : MonoBehaviour
{
    public Rigidbody2D leftBarRb;
    public Rigidbody2D rightBarRb;

    public int totalScore = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftBarRb.AddTorque(30f);
        }
        else
        {
            leftBarRb.AddTorque(-25f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightBarRb.AddTorque(-30f);
        }
        else
        {
            rightBarRb.AddTorque(25f);
        }
    }
}
