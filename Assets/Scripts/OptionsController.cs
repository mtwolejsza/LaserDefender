using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour {

    static OptionsController instance = null;

    public GameObject[] ships;
    public GameObject[] engines;

    private int currentShip = 0;
    private int currentEngines = 0;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    public static GameObject GetShip(int index)
    {
        return instance.ships[index];
    }

    /*public static GameObject GetShip(int index1, int index2)
    {
        return instance.ships[index1, index2];
    }*/

    public static GameObject GetEngines(int index)
    {
        return instance.engines[index];
    }

    public static void SetCurrentShip(int index)
    {
        instance.currentShip = index;
    }

    public static GameObject GetCurrentShip()
    {
        Debug.Log(instance.currentShip);
        return GetShip(instance.currentShip);
    }

    public static void SetCurrentEngines(int index)
    {
        instance.currentEngines = index;
    }

    public static GameObject GetCurrentEngines()
    {
        Debug.Log(instance.currentEngines);
        return GetEngines(instance.currentEngines);
    }
}
