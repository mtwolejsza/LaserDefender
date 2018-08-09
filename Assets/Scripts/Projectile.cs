using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int damage;

	// Use this for initialization
	public virtual void Hit (PlayerController player) {
        player.Damage(damage);
        Hit();
    }

    public virtual void Hit()
    {
        Destroy(gameObject);
    }
}
