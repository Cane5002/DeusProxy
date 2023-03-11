

public class JuggleState : AirState {
    protected KnockDownState.KnockDownType knockdown;

    protected int frame;
    protected int duration;
    public int comboCnt { get; protected set; }

    public JuggleState(Unit _unit, UnitStateMachine _stateMachine, UnitData _data, string _name, UAnimation _animation) : base(_unit, _stateMachine, _data, _name, _animation) {
        duration = 0;
        comboCnt = 0;
        knockdown = KnockDownState.KnockDownType.Soft;
    }

    #region System
    public override void Enter() {
        base.Enter();
        frame = 0;
        comboCnt = 0;
    }

    public override void LogicUpdate() {
        base.LogicUpdate();
        if (frame == duration) stateMachine.ChangeState(unit.KnockDown_S.SetHard(knockdown == KnockDownState.KnockDownType.Hard));
        frame++;
    }
    #endregion

    #region Events
    public override void OnHit(Attack.AttackType type, int duration, bool launcher = false, KnockDownState.KnockDownType knockdown = KnockDownState.KnockDownType.None) {
        base.OnHit(type, duration, launcher, knockdown);
        comboCnt++;
    }
    #endregion

    #region Setters
    public JuggleState SetDuration(int _duration) {
        duration = _duration;
        return this;
    }
    public JuggleState SetKnockDown(KnockDownState.KnockDownType _knockdown) {
        knockdown = _knockdown;
        return this;
    }
    public JuggleState SetComboCount(int count) {
        comboCnt = count;
        return this;
    }
    #endregion
}
