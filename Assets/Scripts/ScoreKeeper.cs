using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    public Text scoreText;
    public Text levelText;
    public static int score;
    public static int level;
    public static int money;

    void Start()
    {
        Reset();
    }

	// Use this for initialization
	public void Reset () {
        score = 0;
        level = 1;
        money = 0;
        writeScore();
        writeLevel();
        writeMoney();
    }
	
	// Update is called once per frame
	public void UpdateScore (int points) {
        score += points;
        writeScore();
	}

    public void LevelFinished()
    {
        level++;
        writeLevel();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        writeMoney();
    }

    private void writeScore()
    {
        scoreText.text = string.Format("Score: {0}", score);
    }

    private void writeLevel()
    {
        levelText.text = string.Format("Level: {0}", level);
    }

    private void writeMoney()
    {
        // TODO write money
    }
}
