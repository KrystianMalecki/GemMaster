using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
    //Maybe other creatures will be able to eat stuff? just for fun.
    public int maxHP;
    [SerializeField]
    public int currentHP;
    public virtual void Start()
    {
        currentHP = 0;
        AddHP(maxHP);
    }
    public virtual void AddHP(int number)
    {
        currentHP += number + currentHP > maxHP ? maxHP - currentHP : number;
    }
    public virtual void Die()
    {
        this.enabled = false;
    }
    public virtual void TakeDamage(int number, Vector2 dir)
    {
        AddHP(-number);
        if (currentHP <= 0)
        {
            Die();
            return;
        }

    }
}
