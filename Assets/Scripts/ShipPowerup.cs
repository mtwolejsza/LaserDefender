using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPowerup : Projectile
{
    public int shipLevel;

    // Use this for initialization
    public void Start()
    {
        damage = 0;
    }

    // Use this for initialization
    public override void Hit(PlayerController player)
    {
        player.UpgradeShip(shipLevel);
        Hit();
    }
}
