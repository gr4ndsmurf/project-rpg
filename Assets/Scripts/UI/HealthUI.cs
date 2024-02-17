using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image healthSlider;
    [SerializeField] private GameObject ui;

    private void Start()
    {
        GetComponent<CharacterStats>().OnHealthChanged += OnHealthChanged;
        ui.SetActive(false);
    }

    void OnHealthChanged(int maxHealth, int currentHealth)
    {
        if (ui != null)
        {
            ui.SetActive(true);
            float healthPercent = (float)currentHealth / maxHealth;
            healthSlider.fillAmount = healthPercent;
            if (currentHealth <= 0)
            {
                Destroy(ui);
            }
        }
    }
}
