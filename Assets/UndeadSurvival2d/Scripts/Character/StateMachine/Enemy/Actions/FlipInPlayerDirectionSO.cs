using Eincode.UndeadSurvival2d.StateMachine;
using Eincode.UndeadSurvival2d.StateMachine.Scriptable;
using UnityEngine;

[CreateAssetMenu(
    fileName = "FlipInPlayerDirectionSO",
    menuName = "StateMachine/Enemy/Actions/Flip in player direction"
)]
public class FlipInPlayerDirectionSO : StateActionSO
{
    public override StateAction CreateAction()
    {
        return new FlipInPlayerDirection();
    }
}

public class FlipInPlayerDirection : StateAction
{

    public override void Awake(StateMachineCore stateMachine)
    {
    }

    public override void OnEnter()
    {
    }

    public override void OnUpdate()
    {
        Debug.Log("Updating Fliping!");
    }
}

