using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundState : UnitState {
    public GroundState(Unit _unit, UnitStateMachine _stateMachine, UnitData _data, string _name, UAnimation _animation) : base(_unit, _stateMachine, _data, _name, _animation) { 
    }

    #region Events
    public override void OnHit(Attack attackData) {
        if (attackData.launcher) stateMachine.ChangeState(unit.Juggle_S.SetDuration(attackData.stunHit).SetKnockDown(attackData.knockdown));
        else stateMachine.ChangeState(unit.Hit_S.SetDuration(attackData.stunHit).SetKnockDown(attackData.knockdown));
    }
    #endregion
}
