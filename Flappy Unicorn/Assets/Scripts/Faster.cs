using UnityEngine;
using System.Collections;

public class Faster : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.GetComponent<Unicorn>() != null)
        {
             GameControl.instance.faster = true;

             GameControl.instance.getFaster();
        }
  
    }
}