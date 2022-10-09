
using UnityEngine;

public class EvadeAnimationOnExitSMB : StateMachineBehaviour
{

    [Header("Channeling")]
    [SerializeField]
    private VoidEventChannelSO _evadeAnimationEvent;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_evadeAnimationEvent != null)
        {
            Debug.Log("Evade Animation Event Raised!");
            _evadeAnimationEvent.RaiseEvent();
        }
    }
}

