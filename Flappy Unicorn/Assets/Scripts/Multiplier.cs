using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplier : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Unicorn>() != null)
        {
            GameControl.instance.multiplier = true;
        }
    }
}
