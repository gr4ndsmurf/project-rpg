using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Controller : MonoBehaviour
{

    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject equipmentUI;

    [SerializeField] private CharacterStats playerStats;
    [SerializeField] private TextMeshProUGUI defense_Text;
    [SerializeField] private TextMeshProUGUI damage_Text;

    private void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    private void OnEquipmentChanged(EquipmentSO newItem, EquipmentSO oldItem)
    {
        defense_Text.text = playerStats.defense.GetValue().ToString();
        damage_Text.text = playerStats.damage.GetValue().ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            equipmentUI.SetActive(!equipmentUI.activeSelf);
        }
    }

    public void OpenCloseUI(GameObject UI_Object)
    {
        UI_Object.SetActive(!UI_Object.activeSelf);
    }
}
