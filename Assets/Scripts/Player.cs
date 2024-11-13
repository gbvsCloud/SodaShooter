using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Shoot> shootQueue = new List<Shoot>();
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int lastShootIndex = 0;
    [SerializeField] private Animator animator;
    [SerializeField] GameObject otta;
    [SerializeField] ShootQueueDisplay shootQueueDisplay;

    public PlayerStats stats = new();

    public void Start()
    {
        
    }

    void FixedUpdate()
    {
        shootQueueDisplay.UpdateShootQueue(shootQueue);
        shootQueueDisplay.UpdateCurrentShoot(lastShootIndex);
    }


    IEnumerator Shoot()
    {
        while(true)
        {
            if(shootQueue.Count <= 0 || gameManager.gs == GameManager.GameState.Start || gameManager.gs == GameManager.GameState.Dead) yield return null;

            if(lastShootIndex >= shootQueue.Count)
            {
                Debug.Log("recarregando");         
                yield return new WaitForSeconds(stats.GetRechargeDelay()); 
                lastShootIndex = 0;
            }
            
            yield return new WaitForSeconds(stats.GetShootDelay());

            Shoot newShoot = Instantiate(shootQueue[lastShootIndex], transform.position, Quaternion.identity);

            lastShootIndex++;
            
            
            
        }
    }



    public IEnumerator StartPlayer()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1.8f);
        otta.SetActive(false);
        animator.SetTrigger("Fly");
        StartCoroutine(Shoot());
    }


    public void EnemyKilled()
    {
        stats.score += 100;
    }

    [System.Serializable]
    public class PlayerStats
    {

        public float defaultRechargeDelay = 2;
        public float defaultShootDelay = 0.6f;

        public int rechargeReductionStack = 0;
        public int shootReductionStack = 0;
        public int criticalChanceStack = 0;
        public int score = 0;

        public float GetRechargeDelay() => defaultRechargeDelay * (float)Math.Pow(0.9, Convert.ToDouble(rechargeReductionStack));
        public float GetShootDelay() => defaultShootDelay * (float)Math.Pow(0.9, Convert.ToDouble(shootReductionStack));

        
    }

}
