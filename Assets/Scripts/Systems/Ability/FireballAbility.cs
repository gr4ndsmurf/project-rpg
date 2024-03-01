using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAbility : IAbility
{
    CharacterStats opponentStats;

    private int abilityDamage = 15;

    public bool isAbilityCooldown = false;
    public float maxCooldown = 10f;
    public float currentCooldown = 10f;

    public void Use(CharacterStats targetStats, Animator animator)
    {
        animator.SetTrigger("fireball");
        opponentStats = targetStats;
        isAbilityCooldown = true;
    }
    public void AbilityHit_AnimationEvent(ParticleSystem ps)
    {
        opponentStats.TakeDamage(abilityDamage);
        ps.Play();
        CameraShake.Shake(0.75f, 0.75f);
    }
}
