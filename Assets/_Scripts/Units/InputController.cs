using System;
using UnityEngine;

public class InputController : MonoBehaviour {
    public event Action<InputState> OnUserInput;

    #region Direction Definitions
    private Vector2 CBack = new Vector2(-1, -1);
    private Vector2 Crouch = new Vector2(0, -1);
    private Vector2 CForward = new Vector2(1, -1);
    private Vector2 Back = new Vector2(-1, 0);
    private Vector2 Neutral = new Vector2(0, 0);
    private Vector2 Forward = new Vector2(1, 0);
    private Vector2 JBack = new Vector2(-1, 1);
    private Vector2 Jump = new Vector2(0, 1);
    private Vector2 JForward = new Vector2(1, 1);
    #endregion
    private Vector2 direction = new Vector2();
    private InputState InputState = new InputState();
    public float right = 0;


    // Update is called once per frame
    void Update() {
        #region Stick Inputs
        Vector2 newdirection = GetDir();
        if (newdirection != direction) {
            InputState.Input = DecodeDir(newdirection);
            InputState.time = Time.time;
            OnUserInput?.Invoke(InputState);
            direction = newdirection;
        }
        #endregion

        #region Button Inputs
        if (Input.GetButtonDown("Punch")) {
            InputState.Input = InputType.Punch;
            InputState.time = Time.time;
            OnUserInput?.Invoke(InputState);
        }
        if (Input.GetButtonDown("Heavy Punch")) {
            InputState.Input = InputType.HPunch;
            InputState.time = Time.time;
            OnUserInput?.Invoke(InputState);
        }
        if (Input.GetButtonDown("Kick")) {
            InputState.Input = InputType.Kick;
            InputState.time = Time.time;
            OnUserInput?.Invoke(InputState);
        }
        if (Input.GetButtonDown("Heavy Kick")) {
            InputState.Input = InputType.Kick;
            InputState.time = Time.time;
            OnUserInput?.Invoke(InputState);
        }
        if (Input.GetButtonDown("Special")) {
            InputState.Input = InputType.Special;
            InputState.time = Time.time;
            OnUserInput?.Invoke(InputState);
        }
        #endregion
    }

    //Functions
    public InputType DecodeDir(Vector2 newdirection) {
        if (newdirection == CBack) {
            return InputType.CBack;
        }
        else if (newdirection == Crouch) {
            return InputType.Crouch;
        }
        else if (newdirection == CForward) {
            return InputType.CForward;
        }
        else if (newdirection == Back) {
            return InputType.Back;
        }
        else if (newdirection == Neutral) {
            return InputType.Neutral;
        }
        else if (newdirection == Forward) {
            Debug.Log("Sending Forward Input");
            return InputType.Forward;
        }
        else if (newdirection == JBack) {
            return InputType.JBack;
        }
        else if (newdirection == Jump) {
            Debug.Log("Sending Jump Input");
            return InputType.Jump;
        }
        else if (newdirection == JForward) {
            return InputType.JForward;
        }
        return InputType.Neutral;
    }

    //Getters
    public Vector2 GetDir() {
        return new Vector2(Input.GetAxisRaw("Horizontal") * right, Input.GetAxisRaw("Vertical"));
    }
    public Vector2 GetRawDirection () {
        return direction;
    }

}

public enum InputType
{
    CBack = 1,
    Crouch = 2,
    CForward = 3,
    Back = 4,
    Neutral = 5,
    Forward = 6,
    JBack = 7,
    Jump = 8,
    JForward = 9,
    Punch = 10,
    HPunch = 11,
    Kick = 12,
    HKick = 13,
    Special = 14
}
public struct InputState {
    public InputType Input;
    public float time;
}

public class InputHandler {
    private InputNode head;
    private int count = 0;
    private float time = 0;

    private float period;
    public class InputNode
    {
        public InputType input;
        public InputNode next = null;

        public InputNode(InputType _input) {
            input = _input;
        }
    }

    public InputHandler(float InputTimePeriod) {
        period = InputTimePeriod;
    }
    //Setters
    public void Push(InputState newInput) {
        float diff = newInput.time - time;
        if (diff > period) {
            //Empty Array
            count = 0;
            head = null;
        }
        if (head == null) head = new InputNode(newInput.Input);
        else {
            InputNode temp = new InputNode(newInput.Input);
            temp.next = head;
            head = temp;
        }
        time = newInput.time;
    }
    //Getters
    public bool Contains(InputType[] inputs) {
        if (count < inputs.Length) return false;
        InputNode temp = head;
        for (int i = 0; i < inputs.Length; i++) {
            if (temp.input != inputs[i]) return false;
            temp = temp.next;
        }
        return true;
    }
}