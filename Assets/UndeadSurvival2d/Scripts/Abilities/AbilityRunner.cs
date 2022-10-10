using UnityEngine;
using Eincode.UndeadSurvival2d.Abilities.Scriptable;
using System.Collections.Generic;

namespace Eincode.UndeadSurvival2d.Abilities
{
    public enum AbilityStatus
    {
        IsReady,
        IsOnCooldown,
        NotFound
    }

    public class AbilityRunner : MonoBehaviour
    {
        [SerializeField]
        private AbilitySO[] _abilitiesSO;

        [Header("Channeling")]
        [SerializeField]
        private AbilityEventChannelSO _abilityAddEvent;

        private List<Ability> _abilities;


        void Start()
        {
            _abilities = new List<Ability>();

            foreach (var abilitySO in _abilitiesSO)
            {
                PrepareAbility(abilitySO);
            }
        }

        void Update()
        {
            foreach (var ability in _abilities)
            {
                if (ability.IsCooldownPending)
                {
                    ability.Cooldown();
                }
                else if (ability.originSO.ExecutionType == AbilityExecutionType.Automatic)
                {
                    ability.Run();
                }
            }
        }

        public AbilityStatus GetAbility(string name, out Ability ability)
        {
            ability = FindAbility(name);

            if (ability == null)
            {
                return AbilityStatus.NotFound;
            }
            else if (ability.IsCooldownPending)
            {
                return AbilityStatus.IsOnCooldown;
            }
            else
            {
                return AbilityStatus.IsReady;
            }
        }

        private void PrepareAbility(AbilitySO abilitySO)
        {
            var ability = abilitySO.GetAbility(this);
            _abilities.Add(ability);

            if (_abilityAddEvent != null)
            {
                _abilityAddEvent.RaiseEvent(ability);
            }
        }

        private Ability FindAbility(string name)
        {
            return _abilities.Find((ability) => ability.originSO.Name == name);
        }
    }


}
