using UnityEngine;

public class SectorBad : Sector
{
    public override void action(Player player)
    {
        player.Died();
        player.Dead = true;
    }
}
