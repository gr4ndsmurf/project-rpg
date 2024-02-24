using System;
using UnityEngine;
using UnityEngine.AI;

public class SmashAbility : IAbility
{
    CharacterStats opponentStats;

    [SerializeField] private int abilityDamage = 25;

    public void Use(CharacterStats targetStats, Animator animator)
    {
        animator.SetTrigger("smash");
        opponentStats = targetStats;
    }

    public void AbilityHit_AnimationEvent()
    {
        opponentStats.TakeDamage(abilityDamage);
    }
}
