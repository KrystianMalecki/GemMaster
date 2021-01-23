using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable id= collision.GetComponent<IDamageable>();
        if (id != null)
        {
            id.TakeDamage(damage,transform.position);
        }
    }
}
