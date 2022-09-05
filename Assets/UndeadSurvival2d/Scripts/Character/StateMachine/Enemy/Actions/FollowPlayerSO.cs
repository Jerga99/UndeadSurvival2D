


using UnityEngine;
using Eincode.UndeadSurvival2d.StateMachine;
using Eincode.UndeadSurvival2d.StateMachine.Scriptable;

[CreateAssetMenu(
    fileName = "FollowPlayerSO",
    menuName = "StateMachine/Enemy/Actions/Follow Player")]
public class FollowPlayerSO : StateActionSO
{
    public override StateAction CreateAction()
    {
        return new FollowPlayer();
    }
}

public class FollowPlayer : StateAction
{

    public override void OnEnter() { }
    public override void OnExit() { }
    public override void OnUpdate()
    {
        Debug.Log("Calling Update of FollowPlayer");
    }
}

