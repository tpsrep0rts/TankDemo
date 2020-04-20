using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : GameActor
{
    const string LEFT_KEY = "a";
    const string RIGHT_KEY = "d";
    const string FORWARD_KEY = "w";
    const string BACKWARD_KEY = "s";
    const string FIRE_KEY = "space";

    const int LEFT_MOUSE = 0;
    const int RIGHT_MOUSE = 1;

    Vector3 mouseWorldPosition;
    Dictionary<string, bool> keysDown;
    Dictionary<int, bool> mouseButtonsDown;
    // Start is called before the first frame update
    void Start()
    {
        keysDown = new Dictionary<string, bool>();
        keysDown.Add(LEFT_KEY, false);
        keysDown.Add(RIGHT_KEY, false);
        keysDown.Add(FORWARD_KEY, false);
        keysDown.Add(BACKWARD_KEY, false);
        keysDown.Add(FIRE_KEY, false);

        mouseButtonsDown = new Dictionary<int, bool>();
        mouseButtonsDown.Add(LEFT_MOUSE, false);
        mouseButtonsDown.Add(RIGHT_MOUSE, false);
    }

    void UpdateKeysDown()
    {
        List<string> keys = new List<string>(keysDown.Keys);
        for(int i = 0; i < keys.Count; i++) { 
            string key = keys[i];
            if (keysDown[key] && Input.GetKeyUp(key)) {
                keysDown[key] = false;
            } else if (!keysDown[key] && Input.GetKeyDown(key)) {
                keysDown[key] = true;
            }
        }
    }

    void UpdateMouseDown()
    {
        List<int> keys = new List<int>(mouseButtonsDown.Keys);
        for (int i = 0; i < keys.Count; i++) {
            int key = keys[i];
            if (mouseButtonsDown[key] && Input.GetMouseButtonUp(key)) {
                mouseButtonsDown[key] = false;
            } else if(!mouseButtonsDown[key] && Input.GetMouseButtonDown(key)) {
                mouseButtonsDown[key] = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateKeysDown();
        UpdateMouseDown();

        mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.transform.position.y - transform.position.y - Camera.main.nearClipPlane
        ));
    }
    public override Vector3 GetTargetLocation()
    {
        return mouseWorldPosition;
    }

    public override bool IsTurningLeft()
    {
        return keysDown[LEFT_KEY] && !keysDown[RIGHT_KEY];
    }
    public override bool IsTurningRight()
    {
        return keysDown[RIGHT_KEY] && !keysDown[LEFT_KEY];
    }
    public override bool IsMovingForward()
    {
        return keysDown[FORWARD_KEY] && !keysDown[BACKWARD_KEY];
    }
    public override bool IsMovingBackward()
    {
        return keysDown[BACKWARD_KEY] &&!keysDown[FORWARD_KEY];
    }
    public override bool IsFiring()
    {
        return mouseButtonsDown[LEFT_MOUSE];
    }

}
