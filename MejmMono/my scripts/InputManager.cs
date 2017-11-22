using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    /// <summary>
    /// This script checks how many fingers are pressed and sets up booleans for the amount of fingers pressed.
    /// Other scripts can easily check for specific amount of fingerpresses for their functions.
    /// </summary>

    public Touch touchZero;
    public Touch touchOne;
    public Touch touchTwo;

    private bool _oneFinger;
    private bool _twoFingers;
    private bool _threefingers;

    // checking the amount of fingerpresses to set up touches and booleans as indicators what touches may be accessed
	void Update ()
    {
        if (Input.touchCount >= 1)
        {
            touchZero = Input.GetTouch(0);
        }
        if (Input.touchCount >= 2)
        {
            touchOne = Input.GetTouch(1);
        }
        if (Input.touchCount >= 3)
        {
            touchTwo = Input.GetTouch(2);
        }

        // setting accessable touches for the amount of fingers pressed
        switch (Input.touchCount)
        {
            case 1:
                _oneFinger = true;
                _twoFingers = false;
                _threefingers = false;
                break;
            case 2:
                _oneFinger = false;
                _twoFingers = true;
                _threefingers = false;
                break;
            case 3:
                _oneFinger = false;
                _twoFingers = false;
                _threefingers = true;
                break;
            default:
                _oneFinger = false;
                _twoFingers = false;
                _threefingers = false;
                break;
        }
	}

    // easy input access for other scripts;
    public bool OneFinger()
    {
        return _oneFinger;
    }

    public bool TwoFingers()
    {
        return _twoFingers;
    }

    public bool ThreeFingers()
    {
        return _threefingers;
    }
}
