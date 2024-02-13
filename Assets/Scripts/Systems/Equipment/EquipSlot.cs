using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Button removeButton;

    ItemSO item;

    public void AddSlot(EquipmentSO newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }
}
