using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("a" + collision.gameObject.name);

        IDamageable id= collision.GetComponent<IDamageable>();
        if (id != null)
        {
            id.TakeDamage(damage,transform.position);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
       // if (collision.otherCollider.isTrigger)
        {
            OnTriggerEnter2D(collision.collider);
        }
    }
}
