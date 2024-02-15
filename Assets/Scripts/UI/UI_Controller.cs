using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class UI_Controller : MonoBehaviour
{

    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject equipmentUI;

    private PlayerStats playerStats;
    [SerializeField] private TextMeshProUGUI defense_Text;
    [SerializeField] private TextMeshProUGUI damage_Text;

    private void Start()
    {
        playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenCloseUI(inventoryUI);
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            OpenCloseUI(equipmentUI);
        }

        if (equipmentUI.activeSelf)
        {
            defense_Text.text = playerStats.defense.GetValue().ToString();
            damage_Text.text = playerStats.damage.GetValue().ToString();
        }
    }

    public void OpenCloseUI(GameObject UI_Object)
    {
        UI_Object.SetActive(!UI_Object.activeSelf);
    }
}
