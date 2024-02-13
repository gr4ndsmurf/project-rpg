using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform itemsParent;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject equipmentUI;

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
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            equipmentUI.SetActive(!equipmentUI.activeSelf);
        }
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
