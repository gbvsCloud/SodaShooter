using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameplayUI;
    [SerializeField] GameObject startUI;
    [SerializeField] GameObject enemySpawner;
    [SerializeField] Player player;
    [SerializeField] PlayerMovement playerMovement;

    AttackSpeedUpgrade attackSpeedUpgrade = new();
    ReloadSpeedUpgrade reloadSpeedUpgrade = new();
    SodaQuantityUpgrade sodaQuantityUpgrade = new();
    [SerializeField] private GameObject HUDUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject registerUI;
    [SerializeField] private GameObject deathUI;

    [SerializeField] private TextMeshProUGUI attackSpeedUpgradeLevel, attackSpeedUpgradeCost, reloadSpeedUpgradeLevel, reloadSpeedUpgradeCost, sodaQuantityUpgradeLevel, sodaQuantityUpgradeCost;
    [SerializeField] private TextMeshProUGUI playerNameTxt;

    public enum GameState
    {
        Start,
        Run,
        Dead,
        Pause,
        Registration

    }

    public GameState gs;


    public void Start()
    {
        ChangeGameState(GameState.Registration);
        UpdateButtonInformation();
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
            registerUI.SetActive(false);
            startUI.SetActive(true);

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

        if(gs == GameState.Dead)
        {
            Time.timeScale = 0;
            deathUI.SetActive(true);

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);


                if (touch.phase == TouchPhase.Began)
                {
                    Time.timeScale = 1;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
            else if(Input.GetButtonDown("Fire1"))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }
        


    }


    public void ChangeGameState(GameState state)
    {
        if(state == gs && state == GameState.Pause)
        {
            Debug.Log("resume");
            ResumeGame();
            return;
        }

        if(state == gs) return;

        gs = state;

        if(gs == GameState.Start)
        {
            gameplayUI.SetActive(false);
            enemySpawner.SetActive(false);
        }
        else if(gs == GameState.Run)
        {
            startUI.SetActive(false);
            player.StartCoroutine(player.StartPlayer());
            StartCoroutine(StartDelay());
            
        }
        else if(gs == GameState.Pause)
        {
            PauseGame();
        }
        

        

    
    }   

    public void OnButtonClick(int index)
    {
        ChangeGameState((GameState)index);
        Debug.Log((GameState)index);
    }

    public void OpenShop()
    {
        Time.timeScale = 0;
        HUDUI.SetActive(false);
        pauseUI.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        HUDUI.SetActive(false);
        pauseUI.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;

        HUDUI.SetActive(true);
        pauseUI.SetActive(false);
        ChangeGameState(GameState.Run);
    }



    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1.8f);
        gameplayUI.SetActive(true);
        enemySpawner.SetActive(true);
        player.enabled = true;
        playerMovement.enabled = true;
    }

    public void BuyAttackSpeedUpgrade()
    {
        if(attackSpeedUpgrade.TryAffordUpgrade(player))
        {
            UpdateButtonInformation();
        }
        

    }
    public void BuyReloadSpeedUpgrade()
    {
        if(reloadSpeedUpgrade.TryAffordUpgrade(player))
        {
            UpdateButtonInformation();
        }
        
    }

    public void BuySodaQuantityUpgrade()
    {
        if(sodaQuantityUpgrade.TryAffordUpgrade(player))
        {
            UpdateButtonInformation();
        }
        
    }

    public void RegisterName(TMP_InputField inputField)
    {
        if(!string.IsNullOrWhiteSpace(inputField.text))
        {
            player.stats.name = inputField.text;
            playerNameTxt.text = player.stats.name;
            ChangeGameState(GameState.Start);
        }
        else
        {
            Debug.Log("Nome inválido!");
        }
    }

    public void UpdateButtonInformation()
    {
        attackSpeedUpgradeLevel.text = $"{attackSpeedUpgrade.upgradeLevel}/{attackSpeedUpgrade.upgradeMaxLevel}";
        attackSpeedUpgradeCost.text = attackSpeedUpgrade.upgradeCost.ToSafeString();

        reloadSpeedUpgradeLevel.text = $"{reloadSpeedUpgrade.upgradeLevel}/{reloadSpeedUpgrade.upgradeMaxLevel}";
        reloadSpeedUpgradeCost.text = reloadSpeedUpgrade.upgradeCost.ToSafeString();

        sodaQuantityUpgradeLevel.text = $"{sodaQuantityUpgrade.upgradeLevel}/{sodaQuantityUpgrade.upgradeMaxLevel}";
        sodaQuantityUpgradeCost.text = sodaQuantityUpgrade.upgradeCost.ToSafeString();
    }

 
    
}
