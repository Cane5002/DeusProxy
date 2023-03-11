using UnityEngine;

public abstract class DeterministicMonoBehaviour : MonoBehaviour {
    private void Awake() {
        GameManager.GameStart += GameStart;
        GameManager.GameUpdate += GameUpdate;
        GameManager.GamePhysicsUpdate += GamePhysicsUpdate;
    }

    protected virtual void GameStart() {}

    protected virtual void GameUpdate() {}

    protected virtual void GamePhysicsUpdate() {}
}
