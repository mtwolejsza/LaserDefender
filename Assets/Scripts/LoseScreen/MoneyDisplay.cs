using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = ScoreKeeper.money.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
