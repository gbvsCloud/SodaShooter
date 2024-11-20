using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private Player player;
    private Player.PlayerStats stats;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    
    public void Start()
    {
        stats = player.stats;
    }


    public void FixedUpdate()
    {
        scoreTxt.text = player.GetScore().ToString();

    }
}
