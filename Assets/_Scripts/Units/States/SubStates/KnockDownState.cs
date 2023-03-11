using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockDownState : GroundState {
    protected bool hard;
    protected int frame;

    protected const int DURATION = 6;

    public KnockDownState(Unit _unit, UnitStateMachine _stateMachine, UnitData _data, string _name, UAnimation _animation) : base(_unit, _stateMachine, _data, _name, _animation) {
    }

    #region System
    public override void Enter() {
        base.Enter();
        frame = 0;
    }

    public override void LogicUpdate() {
        base.LogicUpdate();
        if (frame == DURATION) stateMachine.ChangeState(unit.Idle_S);
        frame++;
    }
    #endregion

    #region Actions
    public void DoGetUp() {
        if(!hard) stateMachine.ChangeState(unit.Idle_S);
    }
    #endregion

    #region Setters
    public KnockDownState SetHard(bool _hard) {
        hard = _hard;
        return this;
    }
    #endregion

    public enum KnockDownType {
        None = 0,
        Soft = 1,
        Hard = 2
    }
}
