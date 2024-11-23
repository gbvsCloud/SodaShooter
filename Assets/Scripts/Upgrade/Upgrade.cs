using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade
{
    public int upgradeCost;
    public int upgradeLevel = 0;
    public int upgradeMaxLevel;

    public abstract bool CanAffordUpgrade();
    public abstract void ApplyUpgrade(Player player);
}
