using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public EquipmentSO[] defaultItems;

    public SkinnedMeshRenderer targetMesh;
    public Transform weaponsTargetBone;
    EquipmentSO[] currentEquipment;
    public EquipSlot[] equipSlots;
    SkinnedMeshRenderer[] currentMeshes;

    public delegate void OnEquipmentChanged(EquipmentSO newItem, EquipmentSO oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new EquipmentSO[numSlots];
        inventory = Inventory.instance;
        currentMeshes = new SkinnedMeshRenderer[numSlots];

        EquipDefaultItems();
    }

    public void Equip (EquipmentSO newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        EquipmentSO oldItem = Unequip(slotIndex);

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;

        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;
        if (newItem.equipSlot == EquipmentSlot.Weapon)
        {
            newMesh.rootBone = weaponsTargetBone;
        }
        else
        {
            newMesh.rootBone = targetMesh.rootBone;
        }
        newMesh.bones = targetMesh.bones;
        currentMeshes[slotIndex] = newMesh;

        // Equipment UI'da görünme kýsmý
        equipSlots[slotIndex].AddSlot(newItem);
    }

    public EquipmentSO Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            if (currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }

            EquipmentSO oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }

            // Equipment UI'da kaldýrma kýsmý
            equipSlots[slotIndex].RemoveSlot();

            return oldItem;
        }

        return null;
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }

        EquipDefaultItems();
    }

    void EquipDefaultItems()
    {
        foreach (EquipmentSO item in defaultItems)
        {
            Equip(item);
        }
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }*/
    }
}
