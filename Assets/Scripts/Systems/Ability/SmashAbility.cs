using System;
using UnityEngine;
using UnityEngine.AI;

public class SmashAbility : IAbility
{
    CharacterStats opponentStats;

    private int abilityDamage = 20;

    public bool isAbilityCooldown = false;
    public float maxCooldown = 20f;
    public float currentCooldown = 20f;

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
        CameraShake.Shake(1f, 1f);
    }
}
