﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Text>().text = ScoreKeeper.level.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
