using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] CharacterData playerData;
    [SerializeField] string playerName;
   // [SerializeField] int playerId;
    [SerializeField] int level;
    [SerializeField] Sprite sprite;
    [SerializeField] int hp;

    private void OnEnable()
    {
      //  playerId = playerData.id;
        level = playerData.level;
        playerName = playerData.characterName;
        sprite = playerData.characterPhoto;
        hp = playerData.hp;
    }
    private void OnValidate()
    {
       // playerId = playerData.id;
        level = playerData.level;
        playerName = playerData.characterName;
        sprite = playerData.characterPhoto;
        hp = playerData.hp;
    }
    //public int PlayerID()
    //{
    //    return playerId;
    //}
    public int Level() { return level; }
    public string PlayerName() { return playerName;}
    public Sprite Sprite() { return sprite;}  
    public int HP() { return hp;}   

}
