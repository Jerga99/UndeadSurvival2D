

using UnityEngine;

namespace Eincode.UndeadSurvival2d.Abilities.Scriptable
{
    public enum AbilityExecutionType
    {
        Automatic, Trigger
    }

    public abstract class AbilitySO : ScriptableObject
    {
        public string Name;
        public GameObject AbilityPrefab;
        public Sprite AbilityIcon;
        public AudioClip SoundEffect;
        public LayerMask CollideWith;
        public bool DestroyOnCollision;
        public AbilityExecutionType ExecutionType;
        public ActionModifierSO[] ActionModifiers;

        public float Cooldown => _cooldown.RuntimeValue;
        public int Damage => _damage.RuntimeValue;

        [SerializeField]
        private FloatValueSO _cooldown;

        [SerializeField]
        private IntValueSO _damage;

        public virtual Ability GetAbility(AbilityRunner runner)
        {
            var ability = CreateAbility();
            ability.originSO = this;
            ability.overallCooldown = Cooldown;
            ability.Awake(runner);
            return ability;
        }

        protected abstract Ability CreateAbility();
    }
}


