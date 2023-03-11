

public class AirState : UnitState {
    public AirState(Unit _unit, UnitStateMachine _stateMachine, UnitData _data, string _name, UAnimation _animation) : base(_unit, _stateMachine, _data, _name, _animation) {
    }

    #region System

    #endregion

    #region Events
    public virtual void OnLand() {
        stateMachine.ChangeState(unit.Idle_S);
    }
    #endregion

    #region Actions
    public override void DoCheck() {
        base.DoCheck();
        //TODO: Check if landed
    }
    #endregion
}
