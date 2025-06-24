using UnityEngine;

public class Potion : MonoBehaviour, IItem
{

    Inventory inventory;
    public enum PotionType { Gold, Hp, Mp }
    public PotionType potionType;

    public GameObject Obj { get; set; }

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