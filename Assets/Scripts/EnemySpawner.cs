using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject[] enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 1f;
    public float spawnDelay = .25f;

    private bool leftMovement = true;
    private bool spawning = false;

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0f));
    }

	// Use this for initialization
	void Start () {
        // Spawning
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        int count = 0;
        foreach (Transform child in transform)
        {
            SpawnEnemy(child);
            count++;
            //Debug.Log(count);
            if (count > 50)
            {
                break;
            }
        }
    }

    void SpawnEnemy(Transform position)
    {
        //TODO clean up with constants
        Position pos = position.GetComponent<Position>();
        int phase = (ScoreKeeper.level - 1) / 10;
        if (phase > 3) { phase = 3; }
        int enemyKey = pos.enemyLevelKey[(ScoreKeeper.level - 1) % 10] + phase * 5;
        GameObject enemy = Instantiate(enemyPrefab[enemyKey], 
            position.position, Quaternion.identity) as GameObject;
        enemy.transform.parent = position;
    }

    void SpawnEnemiesUntilFull()
    {
        Transform nextPos = NextFreePosition();
        if (nextPos)
        {
            SpawnEnemy(nextPos);
            Invoke("SpawnEnemiesUntilFull", spawnDelay);
        } else
        {
            spawning = false;
        }
    }

    // Update is called once per frame
    void Update () {
		if (leftMovement)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= (Space.GetMinX() + (width / 2)))
            {
                leftMovement = false;
            }
        } else
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= (Space.GetMaxX() - (width / 2)))
            {
                leftMovement = true;
            }
        }
        if (!spawning && AllMembersDead())
        {
            ScoreKeeper sk = FindObjectOfType<ScoreKeeper>();
            sk.LevelFinished();
            spawning = true;
            SpawnEnemiesUntilFull();
        }
	}

    bool AllMembersDead()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }

    Transform NextFreePosition()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount == 0)
            {
                return child;
            }
        }
        return null;
    }
}
