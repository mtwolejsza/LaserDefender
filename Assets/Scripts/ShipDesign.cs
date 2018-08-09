using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDesign : MonoBehaviour {

    public Sprite[] shipSprites;
    private Vector3[] engineLocations = new Vector3[3]; //[left, right, center]

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform)
        {
            if (child.position.x == 0) // center
            {
                engineLocations[2] = child.position;
            } else if (child.position.x < 0) // left
            {
                engineLocations[0] = child.position;
            }
            else //right
            {
                engineLocations[1] = child.position;
            }
        }
	}

    public Vector3 GetEngineLocation(int index)
    {
        return engineLocations[index];
    }
}
