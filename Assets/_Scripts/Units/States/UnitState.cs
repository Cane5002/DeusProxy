using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitState {
    protected Unit unit;
    protected UnitStateMachine stateMachine;
    protected UnitData data;

    private string name;
    private UAnimation animation;

    public UnitState(Unit _unit, UnitStateMachine _stateMachine, UnitData _data, string _name, UAnimation _animation) {
        unit = _unit;
        stateMachine = _stateMachine;
        data = _data;
        name = _name;
        animation = _animation;
    }

    #region System
    public virtual void Enter() {
        DoCheck();
        unit.Anim.Play(animation);
    }
    public virtual void Exit() {}

    public virtual void LogicUpdate() {}
    public virtual void PhysicsUpdate() {
        DoCheck();
    }
    #endregion

    #region Events
    public virtual void OnHit(Attack.AttackType type, int duration, bool launcher = false, KnockDownState.KnockDownType knockdown = 0) { }
    public virtual void OnHit(Attack attackData) { }
    #endregion

    #region Actions
    public virtual void DoCheck() {}
    #endregion
}
