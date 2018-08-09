using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyStar : Projectile
{
    public int moneyValue;

    // Use this for initialization
    public void Start()
    {
        damage = 0;
    }

    // Use this for initialization
    public override void Hit(PlayerController player)
    {
        //AudioSource.PlayClipAtPoint(death, transform.position, .8f);
        ScoreKeeper sk = FindObjectOfType<ScoreKeeper>();
        sk.AddMoney(moneyValue);
        Debug.Log(moneyValue);
        Hit();
    }
}
