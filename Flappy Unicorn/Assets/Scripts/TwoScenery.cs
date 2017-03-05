using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoScenery : MonoBehaviour {
    public GameObject Scenery;
    public GameObject Scenery1;
    // Use this for initialization
    void Start () {
        check2();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void check2()
    {
        if (InformationSave.instance.bG3 == true)
        {
            Scenery.SetActive(false);
            Scenery1.SetActive(false);


        }
    }
}
