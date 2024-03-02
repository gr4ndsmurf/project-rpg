using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityRunner : MonoBehaviour
{
    [SerializeField] private IAbility m_currentAbility;
    public IAbility CurrentAbility
    {
        get => m_currentAbility;
        set => m_currentAbility = value;
    }

    private AbilityChanger abilityChanger;
    [SerializeField] private Color32 selectedAbilityColor;
    public ParticleSystem selectedAbilityPS;
    public float abilityRadius;

    [SerializeField] private Image SkillQFrameIMG;
    [SerializeField] private Image SkillQIMG;
    [SerializeField] private TextMeshProUGUI SkillQCooldownTEXT;
    [SerializeField] private ParticleSystem SqillQps;

    [SerializeField] private Image SkillWFrameIMG;
    [SerializeField] private Image SkillWIMG;
    [SerializeField] private TextMeshProUGUI SkillWCooldownTEXT;
    [SerializeField] private ParticleSystem SqillWps;

    [SerializeField] private Image SkillEFrameIMG;
    [SerializeField] private Image SkillEIMG;
    [SerializeField] private TextMeshProUGUI SkillECooldownTEXT;
    [SerializeField] private ParticleSystem SqillEps;

    private void Awake()
    {
        abilityChanger = GetComponent<AbilityChanger>();
    }
    private void Update()
    {
        if (m_currentAbility == abilityChanger.smashAbility)
        {
            ClearCurrentAbility();
            SkillQFrameIMG.color = selectedAbilityColor;
            selectedAbilityPS = SqillQps;
            abilityRadius = 5f;
        }
        else if (m_currentAbility == abilityChanger.spinAttackAbility)
        {
            ClearCurrentAbility();
            SkillWFrameIMG.color = selectedAbilityColor;
            selectedAbilityPS = SqillWps;
            abilityRadius = 1.5f;
        }
        else if (m_currentAbility == abilityChanger.fireballAbility)
        {
            ClearCurrentAbility();
            SkillEFrameIMG.color = selectedAbilityColor;
            selectedAbilityPS = SqillEps;
            abilityRadius = 10f;
        }
        else if (m_currentAbility is null)
        {
            ClearCurrentAbility();
            abilityRadius = 1.5f;
        }

        SkillQTimer();
        SkillWTimer();
        SkillETimer();
    }

    void ClearCurrentAbility()
    {
        SkillQFrameIMG.color = Color.white;
        SkillWFrameIMG.color = Color.white;
        SkillEFrameIMG.color = Color.white;
        selectedAbilityPS = null;
    }

    void SkillQTimer()
    {
        if (abilityChanger.smashAbility.isAbilityCooldown)
        {
            abilityChanger.smashAbility.currentCooldown -= Time.deltaTime;

            int cooldownText = (int)abilityChanger.smashAbility.currentCooldown;
            SkillQCooldownTEXT.gameObject.SetActive(true);
            SkillQCooldownTEXT.text = cooldownText.ToString();
            SkillQIMG.color = Color.black;

            if (abilityChanger.smashAbility.currentCooldown <= 0f)
            {
                abilityChanger.smashAbility.currentCooldown = abilityChanger.smashAbility.maxCooldown;

                abilityChanger.smashAbility.isAbilityCooldown = false;
                SkillQCooldownTEXT.gameObject.SetActive(false);
                SkillQIMG.color = Color.white;
            }
        }
    }

    void SkillWTimer()
    {
        if (abilityChanger.spinAttackAbility.isAbilityCooldown)
        {
            abilityChanger.spinAttackAbility.currentCooldown -= Time.deltaTime;

            int cooldownText = (int)abilityChanger.spinAttackAbility.currentCooldown;
            SkillWCooldownTEXT.gameObject.SetActive(true);
            SkillWCooldownTEXT.text = cooldownText.ToString();
            SkillWIMG.color = Color.black;

            if (abilityChanger.spinAttackAbility.currentCooldown <= 0f)
            {
                abilityChanger.spinAttackAbility.currentCooldown = abilityChanger.spinAttackAbility.maxCooldown;

                abilityChanger.spinAttackAbility.isAbilityCooldown = false;
                SkillWCooldownTEXT.gameObject.SetActive(false);
                SkillWIMG.color = Color.white;
            }
        }
    }

    void SkillETimer()
    {
        if (abilityChanger.fireballAbility.isAbilityCooldown)
        {
            abilityChanger.fireballAbility.currentCooldown -= Time.deltaTime;

            int cooldownText = (int)abilityChanger.fireballAbility.currentCooldown;
            SkillECooldownTEXT.gameObject.SetActive(true);
            SkillECooldownTEXT.text = cooldownText.ToString();
            SkillEIMG.color = Color.black;

            if (abilityChanger.fireballAbility.currentCooldown <= 0f)
            {
                abilityChanger.fireballAbility.currentCooldown = abilityChanger.fireballAbility.maxCooldown;

                abilityChanger.fireballAbility.isAbilityCooldown = false;
                SkillECooldownTEXT.gameObject.SetActive(false);
                SkillEIMG.color = Color.white;
            }
        }
    }
}
