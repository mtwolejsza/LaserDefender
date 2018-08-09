using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineOption : MonoBehaviour {

    public int engineDesignIndex;

    // Update is called once per frame
    public void OnClick()
    {
        Debug.Log("Clicked " + engineDesignIndex);
        OptionsController.SetCurrentEngines(engineDesignIndex);
    }
}
