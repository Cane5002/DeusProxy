using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "New Player Attack")]
public class PlayerAttack : Attack {
    public List<InputType> Input = new List<InputType>();

    public PlayerAttack() {
        Name = "";
        AnimationClip = null;
        Input = new List<InputType>();
    }

    public InputType[] GetInput() {
        return Input.ToArray();
    }

    #region Editor
#if UNITY_EDITOR
    [CustomEditor(typeof(PlayerAttack))]
    public class PlayerAttackEditor : Editor {

        PlayerAttack SUB;

        protected virtual void OnEnable() {
            SUB = (PlayerAttack)target;
        }

        public override void OnInspectorGUI() {
            SUB.Name = EditorGUILayout.TextField("Name", SUB.Name);
            SUB.AnimationClip = (AnimationClip)EditorGUILayout.ObjectField("Animation", SUB.AnimationClip, typeof(AnimationClip), false);
            EditorGUILayout.BeginHorizontal();
            SUB.Level = (Attack.AttackLvl)EditorGUILayout.EnumPopup(SUB.Level);
            SUB.Type = (Attack.AttackType)EditorGUILayout.EnumPopup(SUB.Type);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            SUB.GroundOK = EditorGUILayout.Toggle("GroundOK", SUB.GroundOK);
            SUB.AirOK = EditorGUILayout.Toggle("AirOK", SUB.AirOK);
            EditorGUILayout.EndHorizontal();


            EditorGUILayout.LabelField("Input");
            List<InputType> InputRef = SUB.Input;
            for (int j = 0; j < InputRef.Count; j++) {
                EditorGUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("-", GUILayout.MaxWidth(15), GUILayout.MaxHeight(15))) {
                    InputRef.RemoveAt(j);
                    continue;
                }
                InputRef[j] = (InputType)EditorGUILayout.EnumPopup(SUB.Input[j]);

                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("+", GUILayout.MaxWidth(20), GUILayout.MaxHeight(20))) {
                InputRef.Add(new InputType());
            }
            EditorGUILayout.EndHorizontal();


            SUB.showProps = EditorGUILayout.Foldout(SUB.showProps, "Properties", true);
            if (SUB.showProps) {
                EditorGUI.indentLevel++;
                SUB.Armor = (short)EditorGUILayout.IntField("Armor", (int)SUB.Armor);
                SUB.Invincible = EditorGUILayout.Toggle("Invincible", SUB.Invincible);
                SUB.ATKCancel_OK = EditorGUILayout.Toggle("Attack Cancelable", SUB.ATKCancel_OK);
                SUB.HVYCancel_OK = EditorGUILayout.Toggle("Heavy Cancelable", SUB.HVYCancel_OK);
                SUB.SPCancel_OK = EditorGUILayout.Toggle("Special Cancelable", SUB.SPCancel_OK);
                SUB.SUPERCancel_OK = EditorGUILayout.Toggle("Super Cancelable", SUB.SUPERCancel_OK);
                SUB.CONDCancel_OK = EditorGUILayout.Toggle("Conditional Cancel", SUB.CONDCancel_OK);
                EditorGUI.indentLevel--;
            }
        }

    }
#endif
    #endregion
}
public class PlayerAttackList : AttackList
{
    private Dictionary<InputType, List<PlayerAttack>> Attacks = new Dictionary<InputType, List<PlayerAttack>> 
    {
        { InputType.CBack, new List<PlayerAttack>() },
        { InputType.Crouch, new List<PlayerAttack>() },
        { InputType.CForward, new List<PlayerAttack>() },
        { InputType.Back, new List<PlayerAttack>() },
        { InputType.Neutral, new List<PlayerAttack>() },
        { InputType.Forward, new List<PlayerAttack>() },
        { InputType.JBack, new List<PlayerAttack>() },
        { InputType.Jump, new List<PlayerAttack>() },
        { InputType.JForward, new List<PlayerAttack>() },
        { InputType.Punch, new List<PlayerAttack>() },
        { InputType.HPunch, new List<PlayerAttack>() },
        { InputType.Kick, new List<PlayerAttack>() },
        { InputType.HKick, new List<PlayerAttack>() },
        { InputType.Special, new List<PlayerAttack>() },

    };

    public void Add(PlayerAttack a) {
        bool success = false;
        InputType last = a.Input[a.Input.Count - 1];

        List<PlayerAttack> list = Attacks[last];
        for (int i = 0; i < list.Count; i++) {
            if (list[i].Input.Count < a.Input.Count) {
                list.Insert(i, a);
                success = true;
                break;
            }
        }
        if (!success) list.Add(a);
        Attacks[a.Input[a.Input.Count - 1]] = list;
    }

}