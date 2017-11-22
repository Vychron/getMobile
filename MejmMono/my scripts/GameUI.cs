using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    /// <summary>
    /// This script manages the UI of the Main Game
    /// </summary>

    [SerializeField]
    private RawImage _red;
    [SerializeField]
    private RawImage _blue;
    [SerializeField]
    private RawImage _green;
    [SerializeField]
    private RawImage _yellow;
    private BeardCone _cone;
    private string _coneString;

    void Start()
    {
        _cone = GetComponent<BeardCone>();
        _coneString = _cone.currentColour;
    }
    // Update is called once per frame
    void Update ()
    {
        _coneString = _cone.currentColour;
        switch (_coneString)
        {
            case ("red"):
                _red.enabled = true;
                _blue.enabled = false;
                _green.enabled = false;
                _yellow.enabled = false;
                break;
            case ("blue"):
                _red.enabled = false;
                _blue.enabled = true;
                _green.enabled = false;
                _yellow.enabled = false;
                break;
            case ("green"):
                _red.enabled = false;
                _blue.enabled = false;
                _green.enabled = true;
                _yellow.enabled = false;
                break;
            case ("yellow"):
                _red.enabled = false;
                _blue.enabled = false;
                _green.enabled = false;
                _yellow.enabled = true;
                break;
        }
	}
}
