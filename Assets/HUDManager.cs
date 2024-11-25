using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI goldTxt;
    [SerializeField] private TextMeshProUGUI lifeTxt;
    [SerializeField] private TextMeshProUGUI deathTxt;
     
    public void Start()
    {
    }


    public void FixedUpdate()
    {
        scoreTxt.text = "Score:" + player.stats.score.ToString();
        goldTxt.text = "Gold:" + player.stats.gold.ToString();
        lifeTxt.text = "Life:" + player.stats.life.ToString();
        deathTxt.text = $"{player.stats.name}\nScore:{player.stats.score}";
    }
}
