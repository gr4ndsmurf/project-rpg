using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    private void OnEquipmentChanged(EquipmentSO newItem, EquipmentSO oldItem)
    {
        if (newItem != null)
        {
            defense.AddModifier(newItem.defenseModifier);
            damage.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            defense.RemoveModifier(oldItem.defenseModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }

    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }
}
