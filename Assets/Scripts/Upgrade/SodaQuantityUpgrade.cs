public class SodaQuantityUpgrade : Upgrade
{
    
    public SodaQuantityUpgrade()
    {
        upgradeCost = 200;
        upgradeMaxLevel = 8;
    }

    public override void ApplyUpgrade(Player player)
    {
        player.AddSoda();
        upgradeLevel++;
        upgradeCost += upgradeLevel * 100;
    }


}
