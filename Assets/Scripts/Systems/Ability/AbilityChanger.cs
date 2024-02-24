using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityChanger : MonoBehaviour
{
    private AbilityRunner m_abilityRunner;

    [SerializeField] private Color32 selectedAbilityColor;

    [SerializeField] private Image SkillQFrameIMG;
    [SerializeField] private Image SkillQIMG;
    [SerializeField] private TextMeshProUGUI SkillQCooldownTEXT;

    SmashAbility smashAbility;
    private void Awake()
    {
        m_abilityRunner = GetComponent<AbilityRunner>();
    }

    private void Start()
    {
        m_abilityRunner.CurrentAbility = null;
        smashAbility = new SmashAbility();
    }

    private void Update()
    {
        IAbility currentAbility = m_abilityRunner.CurrentAbility;

        if (Input.GetKeyDown(KeyCode.Q) && currentAbility is not SmashAbility && !smashAbility.isAbilityCooldown)
        {
            m_abilityRunner.CurrentAbility = smashAbility;
            SkillQFrameIMG.color = selectedAbilityColor;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && currentAbility is SmashAbility)
        {
            m_abilityRunner.CurrentAbility = null;
        }
        else if (currentAbility is null)
        {
            SkillQFrameIMG.color = Color.white;
        }


        SkillQTimer();
    }

    void SkillQTimer()
    {
        if (smashAbility.isAbilityCooldown)
        {
            smashAbility.currentCooldown -= Time.deltaTime;

            int cooldownText = (int) smashAbility.currentCooldown;
            SkillQCooldownTEXT.gameObject.SetActive(true);
            SkillQCooldownTEXT.text = cooldownText.ToString();
            SkillQIMG.color = Color.black;

            if (smashAbility.currentCooldown <= 0f)
            {
                smashAbility.currentCooldown = smashAbility.maxCooldown;

                smashAbility.isAbilityCooldown = false;
                SkillQCooldownTEXT.gameObject.SetActive(false);
                SkillQIMG.color = Color.white;
            }
        }
    }
}
