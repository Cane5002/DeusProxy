using System;
using UnityEngine;
using System.Collections.Generic;

public abstract class UnitData : ScriptableObject {
    public string Name { get; protected set; }
    public Sprite Icon { get; protected set; }
    public Stats Stats { get; protected set; }

    public List<UAnimation> Animations { get; protected set; }
    public List<Attack> Attacks { get; protected set; }

    public UAnimation GetAnimation(string animName) {
        foreach (UAnimation a in Animations) {
            if (a.name.Equals(Name + "_" + animName)) return a;
        }
        return null;
    }


}


[Serializable]
public struct Stats
{
    public int Health;
    public int WalkSpeed;
    public int JumpHeight;
}
