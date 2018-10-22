//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//class Controls
//{
//    public KeyBind moveLeft { get; private set; }
//    public KeyBind moveRight { get; private set; }
//    public KeyBind jump { get; private set; }
//    public KeyBind sprint { get; private set; }

//    public Controls(KeyBind moveLeft, KeyBind moveRight, KeyBind jump, KeyBind sprint)
//    {
//        this.moveLeft = moveLeft;
//        this.moveRight = moveRight;
//        this.jump = jump;
//        this.sprint = sprint;
//    }

//    public static Controls Default()
//    {
//        return new Controls(new KeyBind(KeyCode.A) + new KeyBind(KeyCode.LeftArrow), 
//            new KeyBind(0) + new KeyBind(KeyCode.RightArrow), 
//            new KeyBind(KeyCode.Space), 
//            new KeyBind(KeyCode.LeftShift));
//    }
//}

//struct BindState
//{
//    delegate bool Active();
//    Active active;
//    Active altActive;
//    public bool IsActive;
//}

//class KeyBind
//{
//    object keyBind;
//    object altKeyBind;
//    //BindState Pressed = new BindState();
//    delegate bool _Press();
//    _Press Press;
//    _Press AltPress;
//    public bool Pressed;
//    delegate bool _BindDown();
//    _BindDown Down;
//    _BindDown AltDown;
//    public bool BindDown;
//    delegate bool _BindUp();
//    _BindUp Up;
//    _BindUp AltUp;
//    public bool BindUp;

//    //Allows two keybinds to be added together to add an alternitve input to the first one. Could check if alt is null first to determine if anything is overridden.
//    public static KeyBind operator +(KeyBind a, KeyBind b)
//    {
//        a.altKeyBind = b;
//        a.AltPress = b.Press;
//        a.AltDown = b.AltDown;
//        a.AltUp = b.AltUp;
//        return a;
//    }

//    public KeyBind(KeyCode keyCode)
//    {
//        keyBind = keyCode;
//        Press = KeyPressed;
//        Down = KeyDown;
//        Up = KeyUp;
//    }

//    public KeyBind(int mouseButton)
//    {
//        keyBind = mouseButton;
//        Press = MouseButtonPressed;
//    }

//    public bool IsPressed()
//    {
//        if(altKeyBind != null)
//            return AltPress() || Press();
//        return Press();
//    }

//    public bool IsDown()
//    {
//        if(altKeyBind != null)
//            return AltDown() || Down();
//        return Down();
//    }

//    public bool IsUp()
//    {
//        if(altKeyBind != null)
//            return AltUp() || Up();
//        return Up();
//    }

//    bool KeyPressed()
//    {
//        return Input.GetKey((KeyCode)keyBind);
//    }

//    bool MouseButtonPressed()
//    {
//        return Input.GetMouseButton((int)keyBind);
//    }

//    bool KeyDown()
//    {
//        return Input.GetKeyDown((KeyCode)keyBind);
//    }

//    bool MouseButtonDown()
//    {
//        return Input.GetMouseButtonDown((int)keyBind);
//    }

//    bool KeyUp()
//    {
//        return Input.GetKeyUp((KeyCode)keyBind);
//    }

//    bool MouseButtonUp()
//    {
//        return Input.GetMouseButtonUp((int)keyBind);
//    }
//}
