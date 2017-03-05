using UnityEngine;
using System.Collections;

public class Slower : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Unicorn>() != null)
        {
            GameControl.instance.slower = true;

            GameControl.instance.getSlower();
        }
    }
}
