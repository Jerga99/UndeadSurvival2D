

using UnityEngine;
using Eincode.UndeadSurvival2d.Abilities.Scriptable;
using Eincode.UndeadSurvival2d.Abilities.Action;

namespace Eincode.UndeadSurvival2d.Abilities
{
    public abstract class Ability
    {
        public AbilitySO originSO;

        public float overallCooldown;
        public float currentCooldown;

        public ActionModifierSO[] ActionModifiers => originSO.ActionModifiers;
        public bool IsCooldownPending => currentCooldown != 0;

        public abstract void TriggerAbility();

        public virtual void Awake(AbilityRunner runner) { }

        public virtual void Run()
        {
            StartCooldown();
        }

        public virtual void Cooldown()
        {
            RunCooldown();
        }

        protected virtual void RunCooldown()
        {
            if (currentCooldown > 0)
            {
                currentCooldown -= Time.deltaTime;
            }
            else
            {
                currentCooldown = 0;
            }
        }

        protected virtual GameObject InstantiateAbility(out AbilityAction action)
        {
            var go = Object.Instantiate(originSO.AbilityPrefab);

            if (go.TryGetComponent(out AbilityAction _action))
            {
                action = _action;
            }
            else
            {
                action = go.AddComponent<AbilityAction>();
            }

            action.abilitySO = originSO;

            return go;
        }

        private void StartCooldown()
        {
            currentCooldown = overallCooldown;
        }

    }
}



