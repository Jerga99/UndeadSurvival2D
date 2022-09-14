

using UnityEngine;

namespace Eincode.UndeadSurvival2d.Abilities.Scriptable
{
    public abstract class AbilitySO : ScriptableObject
    {
        public GameObject AbilityPrefab;
        public string Name;

        public virtual Ability GetAbility(AbilityRunner runner)
        {
            var ability = CreateAbility();
            ability.originSO = this;
            ability.Awake(runner);
            return ability;
        }

        protected abstract Ability CreateAbility();
    }
}


