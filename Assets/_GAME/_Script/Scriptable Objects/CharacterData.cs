using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "character_", menuName = "ScriptableObject/character")]
public class CharacterData : ScriptableObject
{
    public Sprite characterPhoto;
    public int id;
    public string characterName;
    public int level;
    [Tooltip("Maximo de saude do personagem")]
    public int hp;
    public GameObject characterPrefab;

    [Tooltip("Tempo de recuperação entre dano")]
    public float timeBetweenDamage;
    [Tooltip("Deixe personagem invulneravel entre danos")]
    public bool invulnerableOnDamage = true;
}
