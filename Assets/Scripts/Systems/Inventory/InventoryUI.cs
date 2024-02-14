using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform itemsParent;
    

    Inventory Inventory;

    InventorySlot[] slots;
    void Start()
    {
        Inventory = Inventory.instance;
        Inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    
    void Update()
    {
        
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.items.Count)
            {
                slots[i].AddItem(Inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
