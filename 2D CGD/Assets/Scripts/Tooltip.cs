using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class Tooltip : MonoBehaviour
{
    [SerializeField]
    Text text;

    void Start()
    {
        if(text.text.Contains("_"))
        {
            string[] splitText = text.text.Split('_');
            if(splitText.Length < 3)
                return;
            //Debug.Log(splitText[1]);
            //Debug.Log(splitText[0]);
            //Debug.Log(splitText[2]);
            //Debug.Log(FindObjectOfType<Player>().GetControls());
            //Debug.Log(text.text);
            text.text = splitText[0] + FindObjectOfType<Player>().GetControls().keyBinds[splitText[1]].keyBindName + splitText[2];
        }
    }

    protected void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            text.gameObject.SetActive(true);
        }
    }

    protected void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            text.gameObject.SetActive(false);
        }
    }
}

