using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStats enemyStats;

    private void Start()
    {
        playerManager = PlayerManager.instance;
        enemyStats = GetComponent<CharacterStats>();
    }

    public override void Interact()
    {
        base.Interact();
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        AbilityRunner abilityRunner = playerManager.player.GetComponent<AbilityRunner>();
        Animator playerAnimator = playerManager.player.GetComponentInChildren<Animator>();

        if (playerCombat != null)
        {
            if (abilityRunner.CurrentAbility == null)
            {
                playerCombat.Attack(enemyStats);
            }
            else
            {
                if (playerManager.canAttack)
                {
                    abilityRunner.CurrentAbility.Use(enemyStats, playerAnimator);
                    playerManager.canMove = false;
                    playerManager.canAttack = false;
                }
            }
        }
    }
}
