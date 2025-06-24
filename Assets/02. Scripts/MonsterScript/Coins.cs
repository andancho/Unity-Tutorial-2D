using UnityEngine;

public class Coins : MonoBehaviour, IItem
{
    Inventory inventory;
    public enum CoinType { Gold, Purple, Blue }
    public CoinType coinType;

    public GameObject Obj { get; set; }

    public float price;

    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        Obj = gameObject;
    }

    void OnMouseDown()
    {
        Get();
    }

    public void Get()
    {
        Debug.Log($"{this.name}¿ª »πµÊ«ﬂΩ¿¥œ¥Ÿ.");

        inventory.AddItem(this);

        gameObject.SetActive(false);
    }
}
