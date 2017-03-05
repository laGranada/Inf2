using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingBackground : MonoBehaviour {

    private Rigidbody2D rb2d;
    private float scroll2Speed = -1.5f;

    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();


        rb2d.velocity = new Vector2(scroll2Speed, 0);

    }

    void Update () {

        if (GameControl.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
