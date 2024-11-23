using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public Upgrade upgrade;
    public Player player;

    public void BuyUpgrade()
    {
        if(upgrade.CanAffordUpgrade())
        {
            upgrade.ApplyUpgrade(player);
        }
    }

}
