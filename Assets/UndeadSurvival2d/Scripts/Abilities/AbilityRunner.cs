using UnityEngine;
using Eincode.UndeadSurvival2d.Abilities.Scriptable;
using System.Collections.Generic;

namespace Eincode.UndeadSurvival2d.Abilities
{
    public class AbilityRunner : MonoBehaviour
    {
        [SerializeField]
        private AbilitySO[] _abilitiesSO;

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
                else
                {
                    ability.Run();
                }
            }
        }

        private void PrepareAbility(AbilitySO abilitySO)
        {
            var ability = abilitySO.GetAbility(this);
            _abilities.Add(ability);
        }
    }


}
