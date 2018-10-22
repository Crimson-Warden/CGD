using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Platform : Actor
{
    protected override void Start()
    {
        base.Start();
        //rb.gravityScale = 0;
        //rb.constraints = RigidbodyConstraints2D.FreezeAll;
        tag = "Platform";
    }
}
