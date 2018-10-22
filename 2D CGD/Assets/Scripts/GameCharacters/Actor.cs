using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

abstract class Actor : MonoBehaviour
{
    //public Rigidbody2D rb { get; protected set; }
    public Collider2D hitBox { get; protected set; }

    protected virtual void Start()
    {
        hitBox = GetComponent<Collider2D>();
        if (hitBox == null)
        {
            hitBox = gameObject.AddComponent<BoxCollider2D>();
        }
        //rb = GetComponent<Rigidbody2D>();
        //if (rb == null)
        //    rb = gameObject.AddComponent<Rigidbody2D>();
        //rb.gravityScale = 5;
        //rb.drag = 5;
        //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {

    }

    public virtual void SetUpColliders()
    {
        hitBox = GetComponent<Collider2D>();
        if (hitBox == null)
        {
            hitBox = gameObject.AddComponent<BoxCollider2D>();
        }
    }
}
