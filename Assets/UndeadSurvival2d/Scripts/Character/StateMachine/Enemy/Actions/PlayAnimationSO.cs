

using UnityEngine;
using Eincode.UndeadSurvival2d.StateMachine;
using Eincode.UndeadSurvival2d.StateMachine.Scriptable;

[CreateAssetMenu(
    fileName = "PlayAnimationSO",
    menuName = "StateMachine/Enemy/Actions/PlayAnimation"
)]
public class PlayAnimationSO : StateActionSO
{
    public string AnimatorParam;

    public override StateAction CreateAction()
    {
        return new PlayAnimation(AnimatorParam);
    }
}

public class PlayAnimation : StateAction
{
    private Animator _animator;
    private int _paramHash;

    public PlayAnimation(string animatorParam)
    {
        _paramHash = Animator.StringToHash(animatorParam);
    }

    public override void Awake(StateMachineCore stateMachine)
    {
        _animator = stateMachine.GetComponentInChildren<Animator>();
    }

    public override void OnEnter()
    {
        _animator.SetTrigger(_paramHash);
    }
}

