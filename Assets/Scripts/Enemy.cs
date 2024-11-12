using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 3;
    [SerializeField] private Rigidbody2D rigidBody;

    [SerializeField] private float velocity = 1.5f;


    public void Start()
    {
        rigidBody.velocity = new Vector2(0, -velocity);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
