


using UnityEngine;
using Eincode.UndeadSurvival2d.StateMachine;
using Eincode.UndeadSurvival2d.StateMachine.Scriptable;
using Eincode.UndeadSurvival2d.Manager;

[CreateAssetMenu(
    fileName = "FollowPlayerSO",
    menuName = "StateMachine/Enemy/Actions/Follow Player")]
public class FollowPlayerSO : StateActionSO
{
    public float SpeedModifier;
    public float DistanceToKeep;

    public override StateAction CreateAction()
    {
        return new FollowPlayer();
    }
}

public class FollowPlayer : StateAction
{
    public FollowPlayerSO OriginSO => (FollowPlayerSO)originSO;

    public Vector3 PlayerPosition => GameManager.Instance.GetPlayer().transform.position;
    public Vector3 MyPosition => _myTransform.position;

    private Transform _myTransform;

    public override void Awake(StateMachineCore stateMachine)
    {
        _myTransform = stateMachine.transform;

    }

    public override void OnEnter() { }
    public override void OnExit() { }
    public override void OnUpdate()
    {
        RunAction();
    }

    private void RunAction()
    {
        if (Vector3.Distance(MyPosition, PlayerPosition) <= OriginSO.DistanceToKeep)
        {
            return;
        }

        _myTransform.position = Vector3.MoveTowards(
            MyPosition,
            PlayerPosition,
            Time.deltaTime * OriginSO.SpeedModifier
        );
    }
}

