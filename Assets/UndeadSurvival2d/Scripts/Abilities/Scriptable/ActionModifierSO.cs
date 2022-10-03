
using Eincode.UndeadSurvival2d.Abilities.Action;
using UnityEngine;

namespace Eincode.UndeadSurvival2d.Abilities.Scriptable
{
    public abstract class ActionModifierSO : ScriptableObject
    {
        public virtual ActionModifier GetActionModifier(AbilityAction action)
        {
            var modifier = CreateActionModifier();

            modifier.Awake(action);
            modifier.originSO = this;

            return modifier;
        }

        public abstract ActionModifier CreateActionModifier();
    }
}


