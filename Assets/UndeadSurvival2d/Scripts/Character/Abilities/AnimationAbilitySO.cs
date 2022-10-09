

using UnityEngine;
using System;
using Eincode.UndeadSurvival2d.Abilities;
using Eincode.UndeadSurvival2d.Abilities.Scriptable;

[CreateAssetMenu(
    fileName = "AnimationAbilitySO",
    menuName = "Abilities/Animation Ability"
)]
public class AnimationAbilitySO : AbilitySO
{
    public string AnimationParameter;

    protected override Ability CreateAbility()
    {
        return new AnimationAbility(AnimationParameter);
    }
}

public class AnimationAbility : Ability
{
    private Animator _animator;
    private int _animId;

    public AnimationAbility(string animationParameter)
    {
        _animId = Animator.StringToHash(animationParameter);
    }

    public override void Awake(AbilityRunner runner)
    {
        base.Awake(runner);
        _animator = runner.GetComponentInChildren<Animator>();
    }

    public override void TriggerAbility()
    {
        _animator.SetTrigger(_animId);
    }

    public override void Run()
    {
        base.Run();
        TriggerAbility();
    }
}

