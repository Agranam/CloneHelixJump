using UnityEngine;

public class SectorGood : Sector
{
    public override void action(Player player)
    {
        player.Bounce();
    }
}
