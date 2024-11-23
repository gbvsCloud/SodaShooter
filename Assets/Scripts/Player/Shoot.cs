using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shoot : MonoBehaviour
{
    protected float shootVelocity;
    protected float shootDamage;
    protected float penetration;
    public Player player;
    [SerializeField] protected Rigidbody2D rigidBody;


    protected virtual void Awake()
    {
        Destroy(gameObject, 10);
    }

    protected virtual void Start()
    {
        rigidBody.velocity = new Vector2(shootVelocity, 0);
    }

    

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Enemy"))
        {
            OnEnemyHit(collider?.GetComponent<Enemy>());
            
        }
    }

    protected virtual void OnEnemyHit(Enemy enemy)
    {
        enemy.TakeDamage(shootDamage, player);

        penetration--;
        shootVelocity = 2;
            if(penetration <= 0)
                Destroy(gameObject);
        
    }
}
