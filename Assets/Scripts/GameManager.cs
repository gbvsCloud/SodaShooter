using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameplayUI;
    [SerializeField] GameObject startUI;
    [SerializeField] GameObject enemySpawner;
    [SerializeField] Player player;



    public enum GameState
    {
        Start,
        Run,
        Dead

    }

    public GameState gs;


    public void Start()
    {
        ChangeGameState(GameState.Start);
    }

    void Update()
    {
        Application.targetFrameRate = 60;
        CheckState();
    }

    public void CheckState()
    {
        if(gs == GameState.Start)
        {

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);


                if (touch.phase == TouchPhase.Began)
                {
                    ChangeGameState(GameState.Run);
                }
            }
            else if(Input.GetButtonDown("Fire1"))
            {
                ChangeGameState(GameState.Run);  
            }
        

        }


    }


    public void ChangeGameState(GameState state)
    {
        if(state == gs) return;

        gs = state;

        if(state == GameState.Start)
        {
            gameplayUI.SetActive(false);
            enemySpawner.SetActive(false);
        }

        if(state == GameState.Run)
        {
            startUI.SetActive(false);
            player.StartCoroutine(player.StartPlayer());
            StartCoroutine(StartDelay());
        }

        

    }   

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1.8f);
        gameplayUI.SetActive(true);
        enemySpawner.SetActive(true);
    }
    
}
