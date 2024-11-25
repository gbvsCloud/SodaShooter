using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Player : MonoBehaviour
{
    [SerializeField] private List<Shoot> shootQueue = new List<Shoot>();
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int lastShootIndex = 0;
    [SerializeField] private Animator animator;
    [SerializeField] GameObject otta;
    [SerializeField] ShootQueueDisplay shootQueueDisplay;

    public PlayerStats stats = new();

    public event EventHandler updateHudEvent;

    [SerializeField] private List<Shoot> shootPool = new();

    IEnumerator reload, spawnShoot;


    [SerializeField] private bool canShoot = true;

    [SerializeField] private AudioClip playerDeath, fire;



    public void Start()
    {
        ResetStats();
        GenerateShootQueue();
          
    }

    public void Update()
    {
        if(Input.GetButton("Fire1") && gameManager.gs == GameManager.GameState.Run) Shoot();
    }

    public void FixedUpdate()
    {
        shootQueueDisplay.UpdateShootQueue(shootQueue);
        shootQueueDisplay.UpdateCurrentShoot(lastShootIndex);
    }


    public void Shoot()
    {

        if(shootQueue.Count <= 0 || gameManager.gs == GameManager.GameState.Start || gameManager.gs == GameManager.GameState.Dead || !canShoot) return;

        
        SpawnShoot();
            
            
        
    }



    public void SpawnShoot()
    {
        if(spawnShoot == null && canShoot)
        {
            spawnShoot = ISpawnShoot();
            StartCoroutine(spawnShoot);
        }
    }

   IEnumerator ISpawnShoot()
    {
        if (lastShootIndex < shootQueue.Count)
        {
            canShoot = false;
            Shoot newShoot = Instantiate(shootQueue[lastShootIndex], transform.position, shootQueue[lastShootIndex].transform.rotation);

            newShoot.player = this;

            lastShootIndex++;

            AudioManager.PlaySound(fire);

            if (lastShootIndex >= shootQueue.Count)
            {
                Reload();
            }

            yield return new WaitForSeconds(stats.GetShootDelay());

            canShoot = true;
        }


        spawnShoot = null;
    }


    public void Reload()
    {
        if(reload == null)
        {
            reload = IReload();
            StartCoroutine(reload);
        }

    }
    

    IEnumerator IReload()
    {
        canShoot = false;
        yield return new WaitForSeconds(stats.GetRechargeDelay()); 
        reload = null;
        GenerateShootQueue();
        lastShootIndex = 0;
        canShoot = true;
        
    }

    public void GenerateShootQueue()
    {
        for(int i = 0; i < shootQueue.Count; i++)
        {
            shootQueue[i] = shootPool[UnityEngine.Random.Range(0, shootPool.Count)];
        }
    }


    public IEnumerator StartPlayer()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1.8f);
        otta.SetActive(false);
        animator.SetTrigger("Fly");
    }

    public void AddSoda()
    {
        shootQueue.Add(shootPool[UnityEngine.Random.Range(0, shootPool.Count)]);
    }


    public void EnemyKilled()
    {
        stats.score += UnityEngine.Random.Range(60, 101);
        stats.gold += UnityEngine.Random.Range(30, 61);
        Debug.Log(stats.score);
    }

    public void ResetStats()
    {
        stats = new()
        {
            defaultRechargeDelay = 1.75f,
            defaultShootDelay = 0.5f,
            rechargeReductionStack = 0,
            shootReductionStack = 0,
            criticalChanceStack = 0,
            specialChanceStack = 0,
            score = 0,
            life = 3,
            gold = 0,
        };
    }

    public void TakeDamage()
    {
        stats.life--;
        if(stats.life <= 0)
        {
            AudioManager.PlaySound(playerDeath);
            gameManager.ChangeGameState(GameManager.GameState.Dead);
        }
    }


    [Serializable]
    public class PlayerStats
    {

        public float defaultRechargeDelay;
        public float defaultShootDelay;
        public int rechargeReductionStack;
        public int shootReductionStack;
        public int criticalChanceStack;
        public int specialChanceStack;
        public int score;
        public int gold;
        public int life = 3;
        public string name;

        public float GetSpecialChance() => 5  + (specialChanceStack * 10);
        public float GetRechargeDelay() => defaultRechargeDelay * (float)Math.Pow(0.9, Convert.ToDouble(rechargeReductionStack));
        public float GetShootDelay() => defaultShootDelay * (float)Math.Pow(0.9, Convert.ToDouble(shootReductionStack));

        
    }

}
