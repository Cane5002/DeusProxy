using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : GroundState {
    protected BlockType block;

    protected int frame;
    protected int duration;

    public BlockState(Unit _unit, UnitStateMachine _stateMachine, UnitData _data, string _name, UAnimation _animation) : base(_unit, _stateMachine, _data, _name, _animation) {
    }

    #region System
    public override void Enter() {
        base.Enter();
        frame = 0;
    }

    public override void LogicUpdate() {
        base.LogicUpdate();
        if (frame == duration) {
            stateMachine.ChangeState(unit.Idle_S);
        }

        frame++;
    }
    #endregion

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

    #region Setters
    public BlockState SetDuration(int _duration) {
        duration = _duration;
        return this;
    }
    public BlockState SetBlock(BlockType blockType) {
        block = blockType; 
        return this;
    }
    #endregion

    public enum BlockType {
        None = 0,
        Low = 1,
        High = 2,
        All = 3
    }
}
