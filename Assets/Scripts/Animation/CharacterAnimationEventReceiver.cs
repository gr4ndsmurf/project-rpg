using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimationEventReceiver : MonoBehaviour
{
    [SerializeField] private CharacterCombat combat;
    [SerializeField] private AbilityRunner abilityRunner;
    [SerializeField] private AbilityChanger abilityChanger;

    private void Start()
    {
 
    }

    public void AttackHitEvent()
    {
        combat.AttackHit_AnimationEvent();
    }

    public void AbilityHitEvent()
    {
        abilityRunner.CurrentAbility.AbilityHit_AnimationEvent(abilityChanger.selectedAbilityPS);
    }

    public void ControlPlayer()
    {
        PlayerManager.instance.canMove = true;
        PlayerManager.instance.canAttack = true;
        abilityRunner.CurrentAbility = null;
    }
}
