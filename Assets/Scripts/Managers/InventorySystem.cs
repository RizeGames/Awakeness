using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem instance;

    private bool hasItem = false; 


    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }


    public void AddItem(Sprite itemImage) 
    {
        UISystem.Instance.Item.sprite = itemImage;
        UISystem.Instance.EnableItemImage();
        hasItem = true;
        Debug.Log("the item has been collected");
    }

    public void RemoveItem() 
    {
        UISystem.Instance.Item.sprite = null;
        UISystem.Instance.DisableItemImage();
        hasItem = false;
        Debug.Log("the item has been removed");
    }

    public bool GetHasItem() 
    {
        return hasItem;
    }
}
