

using UnityEngine;
using Eincode.UndeadSurvival2d.Abilities;
using Eincode.UndeadSurvival2d.Abilities.Scriptable;
using Eincode.UndeadSurvival2d.Player;

[CreateAssetMenu(
    fileName = "AnimationAbilitySO",
    menuName = "Abilities/Animation Ability"
)]
public class AnimationAbilitySO : AbilitySO
{
    public string AnimationParameter;
    public float SpeedModifier;

    [Header("Listening")]
    [SerializeField]
    public VoidEventChannelSO _evadeAnimationEvent;

    protected override Ability CreateAbility()
    {
        return new AnimationAbility(AnimationParameter, _evadeAnimationEvent);
    }
}

public class AnimationAbility : Ability
{
    public AnimationAbilitySO OriginSO => (AnimationAbilitySO)base.originSO;

    private Animator _animator;
    private PlayerController _player;
    private int _animId;

    public AnimationAbility(string animationParameter, VoidEventChannelSO evadeEvent)
    {
        _animId = Animator.StringToHash(animationParameter);
        evadeEvent.OnEventRaised += OnEvadeEventFinished;
    }

    public override void Awake(AbilityRunner runner)
    {
        base.Awake(runner);
        _animator = runner.GetComponentInChildren<Animator>();
        _player = runner.GetComponent<PlayerController>();
    }

    public override void TriggerAbility()
    {
        _animator.SetTrigger(_animId);
        _player.speedModifier = OriginSO.SpeedModifier;
    }

    public override void Run()
    {
        base.Run();
        TriggerAbility();
    }

    private void OnEvadeEventFinished()
    {
        _player.speedModifier = 1f;
    }
}

