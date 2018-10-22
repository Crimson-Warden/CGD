using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO write the keybind names based off of Input
//TODO add controller support
class Controls
{
    public Dictionary<string, KeyBind> keyBinds = new Dictionary<string, KeyBind>(); 
    public KeyBind moveLeft { get; private set; }
    public KeyBind moveRight { get; private set; }
    public KeyBind jump { get; private set; }
    public KeyBind sprint { get; private set; }
    public KeyBind char1 { get; private set; }
    public KeyBind char2 { get; private set; }
    public KeyBind char3 { get; private set; }
    public KeyBind interact { get; private set; }

    public Controls(KeyBind moveLeft, KeyBind moveRight, KeyBind jump, KeyBind sprint, KeyBind char1, KeyBind char2, KeyBind char3, KeyBind interact)
    {
        this.moveLeft = moveLeft;
        this.moveRight = moveRight;
        this.jump = jump;
        this.sprint = sprint;
        this.char1 = char1;
        this.char2 = char2;
        this.char3 = char3;
        this.interact = interact;
        keyBinds.Add("moveLeft", this.moveLeft);
        keyBinds.Add("moveRight", this.moveRight);
        keyBinds.Add("jump", this.jump);
        keyBinds.Add("sprint", this.sprint);
        keyBinds.Add("char1", this.char1);
        keyBinds.Add("char2", this.char2);
        keyBinds.Add("char3", this.char3);
        keyBinds.Add("interact", this.interact);
        //keyBinds.Add(this.);
    }

    public static Controls Default()
    {
        return new Controls(new KeyBind(KeyCode.A) + new KeyBind(KeyCode.LeftArrow), 
            new KeyBind(0) + new KeyBind(KeyCode.RightArrow), 
            new KeyBind(KeyCode.Space), 
            new KeyBind(KeyCode.LeftShift),
            new KeyBind(KeyCode.Alpha1),
            new KeyBind(KeyCode.Alpha2),
            new KeyBind(KeyCode.Alpha3), 
            new KeyBind(KeyCode.E));
    }
}

struct BindState
{
    internal delegate bool Active();
    internal Active active;
    internal Active altActive;
    public bool IsActive;
}

class KeyBind
{
    object keyBind;
    object altKeyBind;
    public string keyBindName { get; private set; }
    BindState Pressed = new BindState();
    BindState Down = new BindState();
    BindState Up = new BindState();
    //delegate bool _Press();
    //_Press Press;
    //_Press AltPress;
    //public bool Pressed;
    //delegate bool _BindDown();
    //_BindDown Down;
    //_BindDown AltDown;
    //public bool BindDown;
    //delegate bool _BindUp();
    //_BindUp Up;
    //_BindUp AltUp;
    //public bool BindUp;

    //Allows two keybinds to be added together to add an alternitve input to the first one. Could check if alt is null first to determine if anything is overridden.
    public static KeyBind operator +(KeyBind a, KeyBind b)
    {
        a.altKeyBind = b;
        a.Pressed.altActive = b.Pressed.active;
        a.Down.altActive = b.Down.active;
        a.Up.altActive = b.Up.active;
        return a;
    }

    public KeyBind(KeyCode keyCode)
    {
        keyBind = keyCode;
        keyBindName = keyCode.ToString();
        if(keyBindName.Contains("Alpha"))
            keyBindName = keyBindName.Remove(0, 5);
        Pressed.active = KeyPressed;
        Down.active = KeyDown;
        Up.active = KeyUp;
    }

    public KeyBind(int mouseButton)
    {
        keyBind = mouseButton;
        Pressed.active = MouseButtonPressed;
        Down.active = MouseButtonDown;
        Up.active = MouseButtonUp;
    }

    public bool IsPressed()
    {
        return Pressed.IsActive;
    }

    public bool IsDown()
    {
        return Down.IsActive;
    }

    public bool IsUp()
    {
        return Up.IsActive;
    }

    public void SetPressed()
    {
        if(altKeyBind != null)
            Pressed.IsActive = Pressed.altActive() || Pressed.active();
        else
        Pressed.IsActive = Pressed.active();
    }

    public void SetDown()
    {
        if(altKeyBind != null)
            Down.IsActive = Down.altActive() || Down.active();
        else
            Down.IsActive = Down.active();
    }

    public void SetUp()
    {
        if(altKeyBind != null)
            Up.IsActive = Up.altActive() || Up.active();
        else
            Up.IsActive = Up.active();
    }

    bool KeyPressed()
    {
        return Input.GetKey((KeyCode)keyBind);
    }

    bool KeyDown()
    {
        return Input.GetKeyDown((KeyCode)keyBind);
    }

    bool KeyUp()
    {
        return Input.GetKeyUp((KeyCode)keyBind);
    }

    bool MouseButtonPressed()
    {
        return Input.GetMouseButton((int)keyBind);
    }

    bool MouseButtonDown()
    {
        return Input.GetMouseButtonDown((int)keyBind);
    }

    bool MouseButtonUp()
    {
        return Input.GetMouseButtonUp((int)keyBind);
    }



}
