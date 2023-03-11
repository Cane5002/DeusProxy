using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public void PlayGame() {
        Debug.Log("Playing...");
        SceneManager.LoadScene(Scene.Combat.ToString());
    }

    public void QuitGame() {
        Debug.Log("Quitting...");
        Application.Quit();
    }
    public void SetLocal() {
        GameManager.PlayMode = PlayMode.Local;
        Debug.Log("Set to" + GameManager.PlayMode);
    }
    public void SetHost() {
        GameManager.PlayMode = PlayMode.Host;
        Debug.Log("Set to" + GameManager.PlayMode);
    }
    public void SetClient() {
        GameManager.PlayMode = PlayMode.Client;
        Debug.Log("Set to" + GameManager.PlayMode);
    }
    public void SetServer() {
        GameManager.PlayMode = PlayMode.Server;
        Debug.Log("Set to" + GameManager.PlayMode);
    }
    public void PrevMenu() {
        
    }
}

public enum Scene {
    Menu = 0,
    Combat = 1
}