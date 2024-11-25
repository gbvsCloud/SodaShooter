using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    public Player player;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        {
            player.TakeDamage();
        }
    }

}
