using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Shoot> shootQueue = new List<Shoot>();
    [SerializeField] private int lastShootIndex = 0;

    public void Start()
    {
        StartCoroutine(Shoot());
    }


    IEnumerator Shoot()
    {
        while(true)
        {
            if(shootQueue.Count <= 0) yield return null;

            if(lastShootIndex >= shootQueue.Count) lastShootIndex = 0;

            Shoot newShoot = Instantiate(shootQueue[lastShootIndex], transform.position, Quaternion.identity);

            lastShootIndex++;
            
            yield return new WaitForSeconds(0.5f);
            
        }
    }


}
