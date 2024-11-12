using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Shoot> shootQueue = new List<Shoot>();
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int lastShootIndex = 0;
    [SerializeField] private Animator animator;
    [SerializeField] GameObject otta;

    public void Start()
    {
        
    }


    IEnumerator Shoot()
    {
        while(true)
        {
            if(shootQueue.Count <= 0 || gameManager.gs == GameManager.GameState.Start || gameManager.gs == GameManager.GameState.Dead) yield return null;

            if(lastShootIndex >= shootQueue.Count) lastShootIndex = 0;

            Shoot newShoot = Instantiate(shootQueue[lastShootIndex], transform.position, Quaternion.identity);

            lastShootIndex++;
            
            yield return new WaitForSeconds(0.5f);
            
        }
    }



    public IEnumerator StartPlayer()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1.9f);
        otta.SetActive(false);
        animator.SetTrigger("Fly");
        StartCoroutine(Shoot());
    }


}
