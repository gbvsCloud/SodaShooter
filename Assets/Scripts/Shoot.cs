using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shoot : MonoBehaviour
{
    protected float shootVelocity;
    protected float shootDamage;
    [SerializeField] protected Rigidbody2D rigidBody;


    protected virtual void Start()
    {
        Destroy(gameObject, 10);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Enemy"))
        {
            collider.GetComponent<Enemy>()?.TakeDamage(shootDamage);
            Destroy(gameObject);
        }
    }
}
