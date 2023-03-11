using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : DeterministicMonoBehaviour {
    public UnitStateMachine StateMachine { get; protected set; }
    #region States
    //Ground States
        //Move States
        public MoveState Idle_S { get; protected set; }
        public MoveState FWalk_S { get; protected set; }
        public MoveState BWalk_S { get; protected set; }
        public MoveState BCrouch_S { get; protected set; }
        public MoveState Crouch_S { get; protected set; }
        //Block States
        public BlockState StandBlock_S { get; protected set; }
        public BlockState CrouchBlock_S { get; protected set; }
        //Hit State
        public HitState Hit_S { get; protected set; }
        //Knock Down State
        public KnockDownState KnockDown_S { get; protected set; }
        //Attack States
        public List<AttackState> Attacks_S { get; protected set; }
    //AirStates
    public JumpState Jump_S { get; protected set; }
    public FallState Apex_S { get; protected set; }
    public FallState Fall_S { get; protected set; }
        //Juggle State
        public JuggleState Juggle_S { get; protected set; }
        //Air Attack States
        public List<AirAttackState> AAttacks_S { get; protected set; }
    #endregion

    public UAnimator Anim { get; protected set; }

    [SerializeField] private UnitData data;


    protected virtual void Awake() {
        #region Create State Machine
        StateMachine = new UnitStateMachine();

        Idle_S = new MoveState(this, StateMachine, data, "Idle", data.GetAnimation("Idle"));
        FWalk_S = new MoveState(this, StateMachine, data, "FWalk", data.GetAnimation("FWalk"));
        BWalk_S = new MoveState(this, StateMachine, data, "BWalk", data.GetAnimation("BWalk"), BlockState.BlockType.High);
        BCrouch_S = new MoveState(this, StateMachine, data, "BCrouch", data.GetAnimation("Crouch"), BlockState.BlockType.Low);
        Crouch_S = new MoveState(this, StateMachine, data, "Crouch", data.GetAnimation("Crouch"));
        StandBlock_S = new BlockState(this, StateMachine, data, "Block", data.GetAnimation("Block"));
        CrouchBlock_S = new BlockState(this, StateMachine, data, "CBlock", data.GetAnimation("CBlock"));
        Hit_S = new HitState(this, StateMachine, data, "Hit", data.GetAnimation("Hit"));
        KnockDown_S = new KnockDownState(this, StateMachine, data, "KnockDown", data.GetAnimation("KD"));
        Jump_S = new JumpState(this, StateMachine, data, "Jump", data.GetAnimation("Jump"));
        Apex_S = new FallState(this, StateMachine, data, "Apex", data.GetAnimation("Apex"));
        Fall_S = new FallState(this, StateMachine, data, "Fall", data.GetAnimation("Fall"));
        Juggle_S = new JuggleState(this, StateMachine, data, "Juggle", data.GetAnimation("Juggle"));
        #endregion
    }

    protected override void GameStart() {
        Anim = GetComponent<UAnimator>();

        //TODO: Init stateMachine
    }

    protected override void GameUpdate() {
        StateMachine.CurrentState.LogicUpdate();
    }

    protected override void GamePhysicsUpdate() {
        StateMachine.CurrentState.PhysicsUpdate();
    }
}
