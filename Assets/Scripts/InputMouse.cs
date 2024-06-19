using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputMouse : MonoBehaviour {
    private static InputMouse instance;
    public static InputMouse Instance {
        get {
            if(instance == null) {
                instance = FindObjectOfType<InputMouse>();
            }
            return instance;
        }
    }



    private Vector2 mousePosition;
    public Vector2 MousePosition { get => mousePosition; set => mousePosition = value; }
    

    // input.getmousebuttondown(0)
    private bool leftMouseButtonDown;
    public bool LeftMouseButtonDown { get => leftMouseButtonDown; set => leftMouseButtonDown = value; }

    // input.getmousebuttonup(0)
    private bool leftMouseButtonUp;
    public bool LeftMouseButtonUp { get => leftMouseButtonUp; set => leftMouseButtonUp = value; }


    private void Start() {
        
    }

    private void Update() {
        this.leftMouseButtonDown = Input.GetMouseButtonDown(0);
        this.leftMouseButtonUp = Input.GetMouseButtonUp(0);

        this.mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }



}
