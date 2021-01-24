using UnityEngine;

public class Entity : MonoBehaviour
{
    //Maybe other creatures will be able to eat stuff? just for fun.
    public int maxHP;
    [SerializeField]
    protected int currentHP;
    public virtual void Start()
    {
        currentHP = 0;
        AddHP(maxHP);
    }
    public virtual void AddHP(int number)
    {
        currentHP += number + currentHP > maxHP ? maxHP - currentHP : number;
    }
}
