using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {

    public int[] enemyLevelKey;

	// Use this for initialization
	void OnDrawGizmos () {
        Gizmos.DrawWireSphere(transform.position, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
