using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float strength;
    public GameObject laserPrefab;
    public float laserSpeed = 2f;
    public AudioClip death;
    public AudioClip fire;

    public int pointValue = 100;

    public float frequencyOfFire;
    
    private void FireLaser()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        Rigidbody2D rigi = laser.GetComponent<Rigidbody2D>();
        rigi.velocity = new Vector2(0, -laserSpeed);
        AudioSource.PlayClipAtPoint(fire, transform.position, .8f);
    }

    // Update is called once per frame
    void Update () {
        float fireProbablity = Time.deltaTime * frequencyOfFire;
        if (Random.value <= fireProbablity)
        {
            FireLaser();
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("HIT!");
        Projectile proj = col.gameObject.GetComponent<Projectile>();
        if (proj && proj.CompareTag("Player"))
        {
            strength -= proj.damage;
            proj.Hit();
            
            if (strength <=0)
            {
                AudioSource.PlayClipAtPoint(death, transform.position, .8f);
                ScoreKeeper sk = FindObjectOfType<ScoreKeeper>();
                sk.UpdateScore(pointValue);
                Destroy(gameObject);
            }
        }
    }
}
