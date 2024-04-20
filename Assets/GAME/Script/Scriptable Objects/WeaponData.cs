using UnityEngine;
[CreateAssetMenu(fileName = "weapon_", menuName = "ScriptableObject/Weapons")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
   [TextArea] public string description;
    public int damage;
    [Tooltip("tempo que a bala dura em cena")]
    public float lifeProjectileDuration;
    [Tooltip("velocidade da bala")]
    public float projectileSpeed;
    [Tooltip("tempo entre tiro. quanto menor, mais balas são disparadas")]
    public float fireRate;
    [Tooltip("A bala que será disparada por esta arma")]
    public GameObject projectile;
    public Sprite weaponPhoto;

}
