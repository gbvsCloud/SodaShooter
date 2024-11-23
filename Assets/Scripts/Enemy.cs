using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 3;
    [SerializeField] private Rigidbody2D rigidBody;

    [SerializeField] private float velocity = 0.6f;

    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material damageMaterial;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private IEnumerator IDamageEffect;


    public void Start()
    {
        rigidBody.velocity = new Vector2(-velocity, 0);
        Destroy(gameObject, 30);
    }

    public void TakeDamage(float damage, Player player = null)
    {
        health -= damage;

        if(IDamageEffect != null)
        {
            StopCoroutine(IDamageEffect);
            IDamageEffect = null;
        }
        
        IDamageEffect = DamageEffect();
        StartCoroutine(IDamageEffect);   

        if(health <= 0)
        {
            player?.EnemyKilled();
            Destroy(gameObject);
        }
    }



    IEnumerator DamageEffect()
    {
        spriteRenderer.material = damageMaterial;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.material = normalMaterial;
        IDamageEffect = null;
    }

}
