using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;


    // Use this for initialization
    void Start()
    {
        GameControl.instance.scrollSpeed = -1.5f;

        rb2d = GetComponent<Rigidbody2D>();

        rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);

    }

    void Update()
    {
        GameControl.instance.scalingSpeed();
        rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);

        if (GameControl.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    
}