using UnityEngine;

public class AbilityRunner : MonoBehaviour
{


    private IAbility m_currentAbility;
    public IAbility CurrentAbility
    {
        get => m_currentAbility;
        set => m_currentAbility = value;
    }


}
