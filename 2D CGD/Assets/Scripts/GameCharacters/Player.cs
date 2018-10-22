using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Document how I fixed the landing bug
//It wasn't letting the player jump when the player fell off of a platform and onto another
//After some debugging I found out that the in air boolean wasn't properly reseting when they hit the platform
//Found out that the offset that checked what the player was standing on wasn't large enough

//TODO properly rearrange the code in here and in the player character class
class Player : MonoBehaviour
{
    Controls controls = Controls.Default();
    public bool inAir { get { return _inAir; } set { _inAir = value; Debug.Log(_inAir); } }
    bool _inAir = false;
    public Platform groundUnderThis;
    float speed = 1;
    float speedModifier = 1;
    [SerializeField]
    Camera cam;
    [SerializeField]
    List<PlayerCharacter> playerCharacters = new List<PlayerCharacter>();
    int currentCharacter = 2;
    int swapsAllowed = 10;

    void Start()
    {
        for(int i = 0; i < playerCharacters.Count;i++)
        {
            playerCharacters[i].SetUpColliders();
            if(i == currentCharacter)
                playerCharacters[i].gameObject.SetActive(true);
            else
                playerCharacters[i].gameObject.SetActive(false);
        }
        //Could attempt to load controls from file, otherwise the variable should be initialized when it is declared
    }

    void Update()
    {
        controls.moveLeft.SetPressed();
        controls.moveRight.SetPressed();
        controls.jump.SetPressed();
        controls.sprint.SetPressed();
        controls.char1.SetDown();
        controls.char2.SetDown();
        controls.char3.SetDown();
        controls.interact.SetPressed();
    }

    void FixedUpdate()
    {
        //If the player isn't in the air
        if(inAir == false)
            //Check if they are sprinting and update the speed modifier
            speedModifier = controls.sprint.IsPressed() ?  1.25f : 1;

        if(controls.moveLeft.IsPressed())
        {
            playerCharacters[currentCharacter].rb.velocity += new Vector2(-speed * speedModifier, 0);
            if(playerCharacters[currentCharacter].rb.velocity.x < 0)
                playerCharacters[currentCharacter].GetComponent<SpriteRenderer>().flipX = true;
        }
        if(controls.moveRight.IsPressed())
        {
            playerCharacters[currentCharacter].rb.velocity += new Vector2(speed * speedModifier, 0);
            if(playerCharacters[currentCharacter].rb.velocity.x > 0)
                playerCharacters[currentCharacter].GetComponent<SpriteRenderer>().flipX = false;
        }
        if(controls.jump.IsPressed() && !inAir)
        {
            playerCharacters[currentCharacter].rb.velocity = new Vector2(playerCharacters[currentCharacter].rb.velocity.x, 10 * playerCharacters[currentCharacter].GetJumpHeight());
            inAir = true;
        }
        if(controls.char1.IsDown())
            ChangeCharacter(0);
        if(controls.char2.IsDown())
            ChangeCharacter(1);
        if(controls.char3.IsDown())
            ChangeCharacter(2);
        //Debug.Log(groundUnderThis.GetComponent<Collider2D>().bounds.min + " " + h);
        //
        //if(groundUnderThis != null)
        //{
        //    Debug.Log(hitBox.bounds.min.x + " " + hitBox.bounds.max.x);
        //    Debug.Log(groundUnderThis.GetComponent<Collider2D>().bounds.min.x + " " + groundUnderThis.GetComponent<Collider2D>().bounds.max.x);
        //}

        if(groundUnderThis != null && (playerCharacters[currentCharacter].hitBox.bounds.max.x < groundUnderThis.GetComponent<Collider2D>().bounds.min.x || playerCharacters[currentCharacter].hitBox.bounds.min.x > groundUnderThis.GetComponent<Collider2D>().bounds.max.x))
        {
            Debug.Log("fell");
            groundUnderThis = null;
            inAir = true;
        }

        cam.transform.position = new Vector3(playerCharacters[currentCharacter].gameObject.transform.position.x, playerCharacters[currentCharacter].gameObject.transform.position.y, -10);
    }

    void ChangeCharacter(int character)
    {
        if(character != currentCharacter && character < playerCharacters.Count && swapsAllowed > 0)
        {
            swapsAllowed--;
            playerCharacters[character].transform.position = playerCharacters[currentCharacter].transform.position;
            playerCharacters[character].gameObject.SetActive(true);
            playerCharacters[currentCharacter].gameObject.SetActive(false);
            currentCharacter = character;
        }
    }

    public bool IsInteracting()
    {
        return controls.interact.IsPressed();
    }

    public Controls GetControls()
    {
        return controls;
    }
}
