using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class PlayerCharacter : Actor
{
    [SerializeField]
    public Rigidbody2D rb;
    [SerializeField]
    float jumpHeight = 1;
    [SerializeField]
    bool canBreak = false;

    public float GetJumpHeight()
    {
        return jumpHeight;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Happened");
        //This allows some wall jumping since it doesn't check if the player lands on it from above. 
        //Not really affecting gameplay yet so I won't implement a fix yet.
        if(collision.gameObject.tag == "Platform" && hitBox.bounds.min.y > collision.collider.bounds.max.y - 0.15f)
        {
            Debug.Log(/*hitBox.bounds.min.y/*collision.collider.bounds.min./ + " " + hitBox.bounds.max.y*/"Landed on a platform");
            FindObjectOfType<Player>().inAir = false;
            FindObjectOfType<Player>().groundUnderThis = collision.gameObject.GetComponentInChildren<Platform>();
        }
    }

    public bool GetCanBreak()
    {
        return canBreak;
    }

    public override void SetUpColliders()
    {
        base.SetUpColliders();
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 5;
        rb.drag = 5;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
