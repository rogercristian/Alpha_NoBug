using System;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    [SerializeField] CharacterData characterData;
    public event Action<int> OnLifeChanged;
    public event Action OnDie;

    private int life;
    private DateTime lastTimeDamage;

    public int Life
    {
        get { return life; }
        set
        {
            if (life < 0) return;
            life = value;
            Debug.Log("Life: " + life);
            OnLifeChanged?.Invoke(life);
            if (life == 0)
            {
                OnDie?.Invoke();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Life = characterData.hp;
    }

    public float GetLifeNormalized()
    {
        return (float)life / characterData.hp;
    }
    public bool IsFullHP()
    {
        return life == characterData.hp;
    }
    public bool TakeDamage(int damage)
    {
        if (!CanTakeDamage()) return false;
        Life -= damage;
        lastTimeDamage = DateTime.UtcNow;
        return true;
    }
    private bool CanTakeDamage()
    {
        if (!characterData.invulnerableOnDamage) return true;
        if (characterData.timeBetweenDamage > 0)
        {
            TimeSpan timeSpan = DateTime.UtcNow - lastTimeDamage;

            return timeSpan.TotalSeconds > characterData.timeBetweenDamage;
        }
        return true;
    }
}
