using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Breakable : Tooltip
{
    bool playerInteracting = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerCharacter>().GetCanBreak())
        {
            OnTriggerEnter2D(collision.collider);
            playerInteracting = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerCharacter>().GetCanBreak())
        {
            base.OnTriggerExit2D(collision.collider);
            playerInteracting = false;
        }
    }

    void Update()
    {
        if(playerInteracting)
        {
            if(FindObjectOfType<Player>().IsInteracting())
            {
                gameObject.SetActive(false);
                //TODO add proper animations and stuff
            }
        }
    }
}
