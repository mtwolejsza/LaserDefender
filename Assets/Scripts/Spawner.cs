using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float frequencyOfMoney;

    public GameObject[] moneyPrefabs;

    public float frequencyOfShips;

    public GameObject[] shipPowerupPrefabs;

    // Update is called once per frame
    void Update () {
        float fireProbablity = Time.deltaTime * frequencyOfMoney;
        if (Random.value <= fireProbablity)
        {
            SpawnMoney();
        }
        int phase = (ScoreKeeper.level - 1) / 10;
        if (phase > 2) {
            phase = 2;fireProbablity = Time.deltaTime * frequencyOfShips;
        if (Random.value <= fireProbablity)
        {
            SpawnShipPowerup(phase);
        }
        }

        if (phase > PlayerController.GetShipLevel())
        {
            fireProbablity = Time.deltaTime * frequencyOfShips;
            if (Random.value <= fireProbablity)
            {
                SpawnShipPowerup(phase);
            }
        }
    }

    private void SpawnMoney()
    {
        Vector3 pos = transform.position;
        pos.x = Random.Range(Space.GetMinX(), Space.GetMaxX());

        int moneyKey = 0; // default bronze
        float rnd = Random.Range(0f, 1f);
        if (rnd > .9f)
        {
            moneyKey = 2; // gold
        }
        else  if (rnd > .6f)
        {
            moneyKey = 1; // silver
        }
        GameObject money = Instantiate(moneyPrefabs[moneyKey],
            pos, Quaternion.identity) as GameObject;
    }

    private void SpawnShipPowerup(int phase)
    {
        Vector3 pos = transform.position;
        pos.x = Random.Range(Space.GetMinX(), Space.GetMaxX());

        

        GameObject money = Instantiate(shipPowerupPrefabs[phase - 1],
            pos, Quaternion.identity) as GameObject;
    }
}
