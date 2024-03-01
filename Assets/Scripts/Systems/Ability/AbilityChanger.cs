using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AbilityRunner))]
public class AbilityChanger : MonoBehaviour
{
    private AbilityRunner m_abilityRunner;

    public SmashAbility smashAbility;
    public SpinAttackAbility spinAttackAbility;
    public FireballAbility fireballAbility;
    private void Awake()
    {
        m_abilityRunner = GetComponent<AbilityRunner>();
    }

    private void Start()
    {
        m_abilityRunner.CurrentAbility = null;
        smashAbility = new SmashAbility();
        spinAttackAbility = new SpinAttackAbility();
        fireballAbility = new FireballAbility();
    }

    private void Update()
    {
        IAbility currentAbility = m_abilityRunner.CurrentAbility;

        if (Input.GetKeyDown(KeyCode.Q) && currentAbility is not SmashAbility && !smashAbility.isAbilityCooldown)
        {
            m_abilityRunner.CurrentAbility = smashAbility;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && currentAbility is SmashAbility)
        {
            m_abilityRunner.CurrentAbility = null;
        }
        else if (Input.GetKeyDown(KeyCode.W) && currentAbility is not SpinAttackAbility && !spinAttackAbility.isAbilityCooldown)
        {
            m_abilityRunner.CurrentAbility = spinAttackAbility;
        }
        else if (Input.GetKeyDown(KeyCode.W) && currentAbility is SpinAttackAbility)
        {
            m_abilityRunner.CurrentAbility = null;
        }
        else if (Input.GetKeyDown(KeyCode.E) && currentAbility is not FireballAbility && !fireballAbility.isAbilityCooldown)
        {
            m_abilityRunner.CurrentAbility = fireballAbility;
        }
        else if (Input.GetKeyDown(KeyCode.E) && currentAbility is FireballAbility)
        {
            m_abilityRunner.CurrentAbility = null;
        }

    }

}
