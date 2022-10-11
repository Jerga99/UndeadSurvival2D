using UnityEngine;
using Eincode.UndeadSurvival2d.Abilities.Scriptable;

namespace Eincode.UndeadSurvival2d.Abilities.Action
{
    public abstract class AbilityAction : MonoBehaviour
    {
        public AbilitySO abilitySO;
        public Vector3 direction;
        public float range;
        public float currentDistance;
        public AudioSource audioSource;

        private Collider2D _collider;
        private ActionModifier[] _actionModifiers;

        protected virtual void Start()
        {
            _collider = GetComponent<Collider2D>();

            _actionModifiers = new ActionModifier[abilitySO.ActionModifiers.Length];

            for (var i = 0; i < _actionModifiers.Length; i++)
            {
                var modifier = abilitySO.ActionModifiers[i].GetActionModifier(this);
                _actionModifiers[i] = modifier;
            }
        }

        protected virtual void Update()
        {
            foreach (var modifier in _actionModifiers)
            {
                modifier.Update(this);
            }
        }

        // Reacts to animation event
        public virtual void OnAbilityActivation()
        {
            _collider.enabled = true;
        }

        // Reacts to animation event
        public virtual void OnAbilityDeActivation()
        {
            _collider.enabled = false;
        }

        public void DestroyAction()
        {
            Destroy(gameObject);
        }
    }
}


