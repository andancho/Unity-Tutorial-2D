using UnityEngine;

public class WirelessEarPhone2 : WirelessEarPhone
{
    //public float batterySize;
    //public bool isWirelessCharging;
    public bool isNoiseCancelling;

    //void Charged()
    //{
    //    string message = isWirelessCharging ? "무선 충전" : "유선 충전";
    //    Debug.Log(message);
    //}
    public void Start()
    {
        name = "무선 이어폰 2";
        price = 5500;
        batterySize = 100f;
        releaseYear = 2010;
    }

    public void Noisecancelling()
    {
        isNoiseCancelling = !isNoiseCancelling;

        string message = isWirelessCharging ? "무선 충전" : "유선 충전";
        Debug.Log(message);
    }
}
