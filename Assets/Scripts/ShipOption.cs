using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipOption : MonoBehaviour {

    public int shipDesignIndex;
    
	// Update is called once per frame
	public void OnClick () {
        Debug.Log("Clicked " + shipDesignIndex);
        OptionsController.SetCurrentShip(shipDesignIndex);
	}
}
