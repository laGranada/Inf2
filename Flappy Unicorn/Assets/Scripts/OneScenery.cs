using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneScenery : MonoBehaviour
{
    public GameObject Scenery;
    public GameObject Scenery2;

    // Use this for initialization
    void Start()
    {
        check1();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void check1()
    {
        if (InformationSave.instance.bG2 == true)
        {
            Scenery.SetActive(false);
            Scenery2.SetActive(false);


        }
    }
}