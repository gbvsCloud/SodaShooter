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
    
    public void Start()
    {
    }


    public void FixedUpdate()
    {
        scoreTxt.text = player.stats.score.ToString();

    }
}
