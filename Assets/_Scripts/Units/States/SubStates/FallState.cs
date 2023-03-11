using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : AirState {
    public FallState(Unit _unit, UnitStateMachine _stateMachine, UnitData _data, string _name, UAnimation _animation) : base(_unit, _stateMachine, _data, _name, _animation) {
    }
}
