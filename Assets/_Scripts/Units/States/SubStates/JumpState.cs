using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : AirState {
    protected short x;

    public JumpState(Unit _unit, UnitStateMachine _stateMachine, UnitData _data, string _name, UAnimation _animation) : base(_unit, _stateMachine, _data, _name, _animation) { }

    #region System
    public override void Enter() {
        base.Enter();
        //TODO: Add jump force
    }
    #endregion

    #region Actions
    public override void DoCheck() {
        //TODO: Check y velocity | if 0 -> apex state
    }
    #endregion

    #region Setters
    public JumpState SetX(short _x) {
        x = _x;
        return this;
    }
    #endregion
}
