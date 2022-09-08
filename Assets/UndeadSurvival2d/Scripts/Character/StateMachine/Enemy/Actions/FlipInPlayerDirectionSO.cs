using Eincode.UndeadSurvival2d.Character;
using Eincode.UndeadSurvival2d.Manager;
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
    public Vector3 PlayerPosition => GameManager.Instance.GetPlayer().transform.position;
    public Vector3 MyPosition => _character.transform.position;

    private CharacterBehaviour _character;

    public override void Awake(StateMachineCore stateMachine)
    {
        _character = stateMachine.GetComponent<CharacterBehaviour>();
    }

    public override void OnEnter()
    {
    }

    public override void OnUpdate()
    {
        Flip(MyPosition.x - PlayerPosition.x > 0);
    }

    private void Flip(bool shouldTurnLeft)
    {
        if (shouldTurnLeft && !_character.isFacingLeft ||
            !shouldTurnLeft && _character.isFacingLeft)
        {
            _character.Flip();
        }
    }
}

