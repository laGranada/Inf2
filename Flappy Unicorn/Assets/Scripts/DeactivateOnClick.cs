using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnClick : MonoBehaviour {

    public void DeactivateByName(GameObject name)
    {


        name.SetActive(false);
    }
}
