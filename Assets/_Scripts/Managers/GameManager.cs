using System;
using Unity.Netcode;
using UnityEngine;

public class GameManager : StaticInstance<GameManager> {
    public static event Action GameStart;
    public static event Action GameUpdate;
    public static event Action GamePhysicsUpdate;


    void Start() => ChangeState(GameState.Starting); // Kick the game off with the first state



    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;
    public GameState State { get; private set; }
    public void ChangeState(GameState newState) {
        OnBeforeStateChanged?.Invoke(newState);

        State = newState;
        switch (newState) {
            case GameState.Starting:
                HandleStarting();
                break;
            case GameState.SpawningPlayers:
                HandleSpawningPlayers();
                break;
            case GameState.Combat:
                HandleCombat();
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnAfterStateChanged?.Invoke(newState);

        Debug.Log($"New state: {newState}");
    }

    #region State Handlers
        //START
        public static PlayMode PlayMode { get; set; }
        public static bool Online { get; private set; }
        private void HandleStarting() {
                // Do some start setup, could be environment, cinematics etc
                Debug.Log("TryStart: " + PlayMode);
                Online = true;
                switch (PlayMode) {
                    case PlayMode.Host:
                        Debug.Log("Starting Host...");
                        PlayerManager.PlayerCount = 2;
                        NetworkManager.Singleton.StartHost();
                        break;
                    case PlayMode.Client:
                        Debug.Log("Starting Client...");
                        PlayerManager.PlayerCount = 2;
                        NetworkManager.Singleton.StartClient();
                        break;
                    case PlayMode.Server:
                        Debug.Log("Starting Server...");
                        PlayerManager.PlayerCount = 2;
                        NetworkManager.Singleton.StartServer();
                        break;
                    case PlayMode.Local:
                        Debug.Log("Starting Local....");
                        PlayerManager.PlayerCount = 1;
                        Online = false;
                        break;
                    case PlayMode.Single:
                        Debug.Log("Starting Single....");
                        PlayerManager.PlayerCount = 1;
                        Online = false;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                // Eventually call ChangeState again with your next state
                ChangeState(GameState.SpawningPlayers);
            }

        //PLAYER SPAWN

        public int JoinedPlayers = 0;
        private void HandleSpawningPlayers() {
            if (!Online) PlayerManager.Instance.SpawnPlayers();
            Debug.Log("Spawning Players...");
            //ChangeState(GameState.Combat);
        }
        public void CommitPlayerSpawn() {
            JoinedPlayers++;
            if (JoinedPlayers == PlayerManager.PlayerCount) ChangeState(GameState.Combat);
        }

        //COMBAT

        private void HandleCombat() {
            Debug.Log("Combat...");
        }

    //GAME OVER

    #endregion
}

public enum PlayMode
{
    Local = 0,
    Host = 1,
    Client = 2,
    Server = 3,
    Single = 4
}
/// <summary>
/// This is obviously an example and I have no idea what kind of game you're making.
/// You can use a similar manager for controlling your menu states or dynamic-cinematics, etc
/// </summary>
[Serializable]
public enum GameState
{
    Starting = 0,
    SpawningPlayers = 1,
    Combat = 2,
    Win = 3,
    Lose = 4,
}
