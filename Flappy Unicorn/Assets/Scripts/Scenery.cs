using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenery : MonoBehaviour {

    public GameObject Scenery1;
    public GameObject Scenery2;
    // Use this for initialization
    void Start () {
        check();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void check()
    {
        if (InformationSave.instance.bG1 == true)
        {
            Scenery1.SetActive(false);
            Scenery2.SetActive(false);


        }
    }
}
