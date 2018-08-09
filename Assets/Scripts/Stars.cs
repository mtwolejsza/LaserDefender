using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stars : MonoBehaviour {

    static Stars instance = null;

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
            SceneManager.sceneLoaded += LoadLevel;
        }
    }

    // Update is called once per frame
    public static void Pause () {
        foreach (Transform child in instance.transform)
        {
            ParticleSystem ps = child.GetComponent<ParticleSystem>();
            ps.Pause();
        }
    }

    public static void Resume()
    {
        foreach (Transform child in instance.transform)
        {
            ParticleSystem ps = child.GetComponent<ParticleSystem>();
            ps.Play();
        }
    }

    void LoadLevel(Scene level, LoadSceneMode mode)
    {
        switch (level.name)
        {
            case "Lose":
                Pause();
                break;
            default:
                Resume();
                break;
        }
    }
}
