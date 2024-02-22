using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEventReceiver : MonoBehaviour
{
    [SerializeField] private CharacterCombat combat;

    public void AttackHitEvent()
    {
        combat.AttackHit_AnimationEvent();
    }
}
