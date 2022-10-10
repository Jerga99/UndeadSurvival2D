using UnityEngine;
using UnityEngine.Events;
using Eincode.UndeadSurvival2d.Abilities;

[CreateAssetMenu(menuName = "Events/Ability Event Channel")]
public class AbilityEventChannelSO : ScriptableObject
{
    [TextArea] public string Description;

    public UnityAction<Ability> OnEventRaised;

    public void RaiseEvent(Ability ability)
    {
        if (OnEventRaised != null)
        {
            OnEventRaised.Invoke(ability);
        }
    }
}

