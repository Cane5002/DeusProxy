using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif



public abstract class Attack : ScriptableObject {
    public string Name;
    public UAnimation animation;
    public AnimationClip AnimationClip;

    public UnitState enterState;
    public UnitState exitState;

    public AttackLvl Level;
    public bool low, high;

    // Properties
    public int damage_t, damage_s;
    public Vector2Int force_t, force_s;
    public int stunHit, stunBlock;

    // Options
    public short Armor;
    public KnockDownState.KnockDownType knockdown;
    public bool launcher;



    public bool Invincible;
    public bool ATKCancel_OK;
    public bool HVYCancel_OK;
    public bool SPCancel_OK;
    public bool SUPERCancel_OK;
    public bool CONDCancel_OK;

    public int Moveset;
    public bool AirOK, GroundOK;
    public AttackType Type;

    // Functions
    public bool Valid(bool grounded) {
        return false;
    }


    public enum AttackLvl
    {
        Basic = -1,
        Normal = 0,
        Heavy = 1,
        Special = 2,
        Super = 3,
        Taunt = 4,
        Conditional = 5,
    }
    public enum AttackType
    {
        High = 0,
        Mid = 1,
        Low = 2,
        Projectile = 3,
        Unblockable = 4,
        State = 5
    }
    #region Editor
#if UNITY_EDITOR
    public bool show, showProps;
    /*
    [CustomEditor(typeof(Attack))]
    public class AttackEditor : Editor {

        Attack SUB;

        protected virtual void OnEnable() {
            SUB = (Attack)target;
        }

        public override void OnInspectorGUI() {
            SUB.Name = EditorGUILayout.TextField("Name", SUB.Name);
            SUB.Animation = (AnimationClip)EditorGUILayout.ObjectField("Animation", SUB.Animation, typeof(AnimationClip), false);
            EditorGUILayout.BeginHorizontal();
            SUB.Level = (Attack.AttackLvl)EditorGUILayout.EnumPopup(SUB.Level);
            SUB.Type = (Attack.AttackType)EditorGUILayout.EnumPopup(SUB.Type);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            SUB.GroundOK = EditorGUILayout.Toggle("GroundOK", SUB.GroundOK);
            SUB.AirOK = EditorGUILayout.Toggle("AirOK", SUB.AirOK);
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
    */
#endif
    #endregion

}
public class AttackList
{
    private List<Attack> Attacks = new List<Attack>();
    public void Add(Attack a) {
        Attacks.Add(a);
    }
}