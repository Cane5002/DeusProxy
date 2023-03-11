using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BlockState;

public class MoveState : GroundState {
    protected BlockType block;
    protected bool crouching;

    public MoveState(Unit _unit, UnitStateMachine _stateMachine, UnitData _data, string _name, UAnimation _animation, BlockType _block = BlockType.None) : base(_unit, _stateMachine, _data, _name, _animation) {
        block = _block;
    }

    #region Events
    public override void OnHit(Attack attackData) {
        //Hit
        if (block == BlockType.None ||
            (block == BlockType.High && attackData.low) ||
            (block == BlockType.Low && attackData.high)) base.OnHit(attackData);
        //Low Block
        else if (block == BlockType.Low) stateMachine.ChangeState(unit.CrouchBlock_S);
        //High Block
        else if (block == BlockType.High) stateMachine.ChangeState(unit.StandBlock_S);
    }
    #endregion

    #region Actions
    public void DoCBlock() => stateMachine.ChangeState(unit.BCrouch_S);
    public void DoCrouch() => stateMachine.ChangeState(unit.Crouch_S);
    public void DoBack() => stateMachine.ChangeState(unit.BWalk_S);
    public void DoIdle() => stateMachine.ChangeState(unit.Idle_S);
    public void DoForward() => stateMachine.ChangeState(unit.FWalk_S);
    public void DoJump(short direction) => stateMachine.ChangeState(unit.Jump_S.SetX(direction));

    public void DoAttack(Attack attack) {
        stateMachine.ChangeState(new AttackState(unit, stateMachine, data, attack));
    }
    #endregion

    //PlayerMoveState
    public void OnMovement(InputType input) {
        switch (input) {
            case InputType.CBack:
                DoCBlock();
                break;
            case InputType.Crouch:
            case InputType.CForward:
                DoCrouch();
                break;
            case InputType.Back:
                DoBack();
                break;
            case InputType.Neutral:
                DoIdle();
                break;
            case InputType.Forward:
                DoForward();
                break;
            case InputType.JBack:
                DoJump(-1);
                break;
            case InputType.Jump:
                DoJump(0);
                break;
            case InputType.JForward:
                DoJump(1);
                break;
        }
    }

}
