using UnityEngine;

public interface IAbility
{
    void Use(CharacterStats targetStats, Animator animator);
    public void AbilityHit_AnimationEvent();
}
