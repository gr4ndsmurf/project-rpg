using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
    [SerializeField] Image icon;

    ItemSO item;

    public void AddSlot(EquipmentSO newItem)
    {
        item = newItem;

        if (!item.isDefaultItem)
        {
            icon.sprite = item.icon;
            icon.enabled = true;
        }
        else
        {
            item = null;
            icon.sprite = null;
            icon.enabled = false;
        }
    }

    public void RemoveSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
