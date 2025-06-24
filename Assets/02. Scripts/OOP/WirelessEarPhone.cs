using UnityEngine;

public class WirelessEarPhone : EarPhone
{
    public float batterySize;
    public bool isWirelessCharging;

    void Charged()
    {
        string message = isWirelessCharging ? "무선 충전" : "유선 충전";
        Debug.Log(message);
    }

    
}
