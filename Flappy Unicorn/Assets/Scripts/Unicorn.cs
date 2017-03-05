using UnityEngine;
using System.Collections;

public class Unicorn : MonoBehaviour
{
    public float upForce = 200f;                
    private bool isDead = false;            
    private Rigidbody2D rb2d;               
    private Animator anim;                  
    

    void Start()
    {
 
        rb2d = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        
    }

    void Update()
    {

        if (isDead == false)
        { 

            if (Input.GetMouseButtonDown(0))
            {

                rb2d.velocity = Vector2.zero;
                    new Vector2(rb2d.velocity.x, 0);
                //upward force
                rb2d.AddForce(new Vector2(0, 200));

                anim.SetTrigger("Flap");

                
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        rb2d.velocity = Vector2.zero;

        isDead = true;

        anim.SetTrigger("Die");

        rb2d.velocity = Vector2.zero;

        GameControl.instance.UnicornDied();
    }
}

