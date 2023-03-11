using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : StaticInstance<PlayerManager> {

    #region Character Data
    public static short PlayerCount;
    public static GameObject PlayerPrefab;
    public static PlayerData Player1Param { get; set; }
    private Vector3 spawnPoint = new Vector3(0, 1.5f, 0);
    public static PlayerData Player2Param { get; set; }
    private static List<GameObject> Players = new List<GameObject>();
    #endregion

    #region Player Setup
    //Network Player
    public void SetupPlayer(GameObject player) {
        Players.Add(player);
    }
    public void SetupPlayer(GameObject player, string unitbase) {
        Players.Add(player);
    }

    //Local Player
    public void SpawnPlayers() {
        Debug.Log("Spawning Players...");
        SpawnUnit(Player1Param, spawnPoint);
    }
    void SpawnUnit(PlayerData t, Vector3 pos) {
        var spawned = Instantiate(PlayerPrefab, pos, Quaternion.identity, transform);


        Players.Add(spawned.gameObject);
    }
    #endregion

    #region Getters
    public static int GetPlayerNum(GameObject player) {
        return Players.IndexOf(player) + 1;
    }

    public string GetPlayer1Name() {
        return Player1Param.Name;
    }

    #endregion
}
