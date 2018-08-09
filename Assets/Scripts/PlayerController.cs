using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float movePerFrame;
    public GameObject[] laserPrefab;
    public float fireRate = .5f;
    public Text healthText;
    public Text livesText;
    public float laserSpeed = 2f;
    public float[] health;
    public AudioClip fire;
    public int lives;

    private float lastFireTime = 0f;
    private GameObject shipDesign;

    private bool alive = true;
    private float currentHealth = 100f;
    private static int currentShipLevel = 0;
    private int currentLives = 0;

    // Use this for initialization
    void Start () {
        shipDesign = OptionsController.GetCurrentShip();
        // Initialize Play
        currentLives = lives;
        NewLife();
        
        // Get Engines
        GameObject engines = OptionsController.GetCurrentEngines();
        foreach (Transform child in engines.transform)
        {
            Vector3 pos;
            if (child.position.x == 0)
            {
                pos = shipDesign.transform.FindChild("Center Engine").position;
            } else if (child.position.x < 0)
            {
                pos = shipDesign.transform.FindChild("Left Engine").position;
            } else {
                pos = shipDesign.transform.FindChild("Right Engine").position;
            }
            GameObject go = Instantiate(child.gameObject,
            pos + transform.position, Quaternion.identity) as GameObject;
            go.transform.parent = transform;
        }
    }

    private void NewLife()
    {
        currentShipLevel = 0;
        alive = true;
        NewShip();
    }

    private void SetHealth()
    {
        currentHealth = health[currentShipLevel];
        WriteHealth();
    }

    private void GetShip()
    {
        Debug.Log(shipDesign);
        GetComponent<SpriteRenderer>().sprite = shipDesign.GetComponent<ShipDesign>().shipSprites[currentShipLevel];
    }

    private void NewShip()
    {
        SetHealth();
        GetShip();
    }
	
	// Update is called once per frame
	void Update () {
        if (alive)
        {
            /*if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * movePerFrame * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * movePerFrame * Time.deltaTime;
            }*/
            transform.position += new Vector3(Input.acceleration.x, 0, 0) * movePerFrame * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                InvokeRepeating("FireLaser", 0f, fireRate);
            }
            else if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
            {
                CancelInvoke("FireLaser");
            }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, Space.GetMinX(), Space.GetMaxX()), transform.position.y, transform.position.z);
        }
	}

    private void FireLaser()
    {
        if (Time.timeSinceLevelLoad < lastFireTime + fireRate - .02f)
        {
            return;
        }
        lastFireTime = Time.timeSinceLevelLoad;
        GameObject laser = Instantiate(laserPrefab[currentShipLevel], transform.position, Quaternion.identity) as GameObject;
        Rigidbody2D rigi = laser.GetComponent<Rigidbody2D>();
        rigi.velocity = new Vector2(0, laserSpeed);
        AudioSource.PlayClipAtPoint(fire, transform.position, .8f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("HIT!");
        Projectile proj = col.gameObject.GetComponent<Projectile>();
        if (alive && proj && !proj.CompareTag("Player"))
        {
            //currentHealth -= proj.damage;
            //WriteHealth();
            proj.Hit(this);
        }
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        WriteHealth();
        if (currentHealth <= 0)
        {
            CancelInvoke("FireLaser");
            currentLives--;
            alive = false;
            if (currentLives <= 0)
            {
                LevelManager lm = GameObject.FindObjectOfType<LevelManager>();
                lm.LoadLevel("Lose");
                Destroy(gameObject);
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = null;
                Invoke("NewLife", 1f);
            }
        }
    }

    public void UpgradeShip(int level)
    {
        if (level > currentShipLevel)
        {
            currentShipLevel = level;
            NewShip();
        }
    }

    private void WriteHealth()
    {
        healthText.text = string.Format("Health: {0}", currentHealth);
    }

    private void WriteLives()
    {
        livesText.text = string.Format("Lives: {0}", currentLives);
    }

    public static int GetShipLevel()
    {
        return currentShipLevel;
    }
}
