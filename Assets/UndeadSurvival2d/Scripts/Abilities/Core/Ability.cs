

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

        public bool DestroyOnCollision => originSO.DestroyOnCollision;
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


        private void StartCooldown()
        {
            currentCooldown = overallCooldown;
        }
    }

    public abstract class Ability<T> : Ability where T : AbilityAction
    {
        protected virtual GameObject InstantiateAbility(out T action)
        {
            var go = Object.Instantiate(originSO.AbilityPrefab);

            if (go.TryGetComponent(out T _action))
            {
                action = _action;
            }
            else
            {
                action = go.AddComponent<T>();
            }

            action.abilitySO = originSO;

            return go;
        }
    }
}



