using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * For global values including
 * - edges
 * - pause
 */
public class Space : MonoBehaviour {

    static Space instance = null;

    float minX;
    float maxX;
    float padding = .5f;

    //public GameObject pauseMenuPrefab;
    //public GameObject canvas;
    public GameObject pauseMenu;

    // Use this for initialization
    void Awake () {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            
            float distance = transform.position.x - Camera.main.transform.position.z;
            Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
            Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));
            minX = leftMost.x + padding;
            maxX = rightMost.x - padding;
            
            Unpause();
        }
    }
	
    public static float GetMinX()
    {
        if (instance != null)
        {
            return instance.minX;
        }
        return 0f;
    }

    public static float GetMaxX()
    {
        if (instance != null)
        {
            return instance.maxX;
        }
        return 0f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        Vector3 pos = pauseMenu.transform.position;
        Debug.Log(GetMaxX().ToString());
        pos.x = Screen.width / 2f;
        pauseMenu.transform.position = pos;
    }

    public void Unpause()
    {
        //TODO this is a hack.  change it
        Vector3 pos = pauseMenu.transform.position;
        pos.x = -5000f;
        pauseMenu.transform.position = pos;
        Time.timeScale = 1f;
    }

    /*public static void Pause()
    {
        if (instance != null)
        {
            instance.DoPause();
        }
    }

    public void Unpause()
    {
        if (instance != null)
        {
            instance.DoUnpause();
        }
    }*/
}
