using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InformationSave : MonoBehaviour {

    public bool bG1 = false;
    public bool bG2 = false;
    public bool bG3 = false;
    public static InformationSave instance = null;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Überprüfen ob es exsitiert
        if (instance == null)

            //wenn nicht, dann auf this setzen 
            instance = this;

        else if (instance != this)

            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void back1()
    {
        bG1 = true;
        bG2 = false;
        bG3 = false;

    }

    public void back2()
    {
        bG1 = false;
        bG2 = true;
        bG3 = false;

    }

    public void back3()
    {
        bG1 = false;
        bG2 = false;
        bG3 = true;

    }

}
