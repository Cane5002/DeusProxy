

public class AttackState : GroundState {
    Attack attackData;
    public AttackState(Unit _unit, UnitStateMachine _stateMachine, UnitData _data, Attack _attackData) : base(_unit, _stateMachine, _data, _attackData.Name, _attackData.animation) {
        attackData = _attackData;
    }
}
