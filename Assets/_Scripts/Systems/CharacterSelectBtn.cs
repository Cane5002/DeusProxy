using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectBtn : MonoBehaviour
{
    public PlayerData PlayerUnit;
    public Image MenuSprite;
    void Start() {
        MenuSprite.sprite = PlayerUnit.Icon;
    }

    public void Selected() {
        PlayerManager.Player1Param = PlayerUnit;
    }

}
