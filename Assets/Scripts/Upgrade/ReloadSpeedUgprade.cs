public class ReloadSpeedUpgrade : Upgrade
{
    
    public ReloadSpeedUpgrade()
    {
        upgradeCost = 150;
        upgradeMaxLevel = 20;
    }

    public override void ApplyUpgrade(Player player)
    {
        player.stats.rechargeReductionStack++;
        upgradeLevel++;
        upgradeCost += upgradeLevel * 75;
    }


}
