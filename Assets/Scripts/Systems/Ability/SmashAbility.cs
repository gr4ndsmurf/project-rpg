using System;
using UnityEngine;
using UnityEngine.AI;

public class SmashAbility : IAbility
{
    CharacterStats opponentStats;

    private int abilityDamage = 25;

    public bool isAbilityCooldown = false;
    public float maxCooldown = 10f;
    public float currentCooldown = 10f;

    public void Use(CharacterStats targetStats, Animator animator)
    {
        animator.SetTrigger("smash");
        opponentStats = targetStats;
        isAbilityCooldown = true;
    }

    public void AbilityHit_AnimationEvent(ParticleSystem ps)
    {
        opponentStats.TakeDamage(abilityDamage);
        ps.Play();
    }
}
