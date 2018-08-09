using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource music;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        } else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            LoadLevel(0);
            SceneManager.sceneLoaded += OnLevelLoad;
        }
	}

    void OnLevelLoad(Scene level, LoadSceneMode mode)
    {
        LoadLevel(level.buildIndex);
    }

    // Update is called once per frame
    void LoadLevel(int level) {
        Debug.Log("Music " + level);
        music.Stop();
        switch (level)
        {
            case 0:
            case 1:
                music.clip = startClip;
                break;
            case 2:
                music.clip = gameClip;
                break;
            case 3:
                music.clip = endClip;
                break;
        }
        music.loop = true;
        music.Play();
    }
}
