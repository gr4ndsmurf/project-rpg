using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityChanger : MonoBehaviour
{
    private AbilityRunner m_abilityRunner;

    private void Awake()
    {
        m_abilityRunner = GetComponent<AbilityRunner>();
    }

    private void Start()
    {
        m_abilityRunner.CurrentAbility = null;
    }

    private void Update()
    {
        IAbility currentAbility = m_abilityRunner.CurrentAbility;

        if (Input.GetKeyDown(KeyCode.Q) && currentAbility is not SmashAbility)
        {
            m_abilityRunner.CurrentAbility = new SmashAbility();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && currentAbility is SmashAbility)
        {
            m_abilityRunner.CurrentAbility = null;
        }
    }
}
