

using UnityEngine;
using Eincode.UndeadSurvival2d.Abilities.Scriptable;

namespace Eincode.UndeadSurvival2d.Abilities
{
    public abstract class Ability
    {
        public AbilitySO originSO;

        public abstract void TriggerAbility(AbilityRunner runner);

        public virtual void Awake(AbilityRunner runner) { }
        public virtual void Run() { }

        protected virtual GameObject InstantiateAbility(AbilityRunner runner)
        {
            var go = Object.Instantiate(
                originSO.AbilityPrefab,
                runner.transform.position,
                Quaternion.identity
            );

            return go;
        }
    }
}



