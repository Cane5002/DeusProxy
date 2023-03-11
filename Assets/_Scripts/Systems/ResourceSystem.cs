using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// One repository for all scriptable objects. Create your query methods here to keep your business logic clean.
/// I make this a MonoBehaviour as sometimes I add some debug/development references in the editor.
/// If you don't feel free to make this a standard class
/// </summary>
public class ResourceSystem : StaticInstance<ResourceSystem> {

    //My Game
    public List<PlayerData> PlayerUnits { get; private set; }
    private Dictionary<string, PlayerData> _PlayerUnitsDict;

    protected override void Awake() {
        base.Awake();
        AssembleResources();
    }

    private void AssembleResources() {
        //My Game
        PlayerUnits = Resources.LoadAll<PlayerData>("Units/PlayerUnits").ToList();
        _PlayerUnitsDict = PlayerUnits.ToDictionary(r => r.Name, r => r);
    }

    //My Game
    public PlayerData GetPlayerUnit(string name) => _PlayerUnitsDict[name];
    public PlayerData GetRandomLegend() => PlayerUnits[Random.Range(0, PlayerUnits.Count)];
}   
