using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerTurn : MonoBehaviour {

    /// <summary>
    /// This script will decide which player's cones can be moved depending on the player's turn
    /// </summary>

    [SerializeField]
    public int players = 2;
    public string currentPlayer = "red";
    private string _nextPlayer;
    private BeardCone _cone;
    [SerializeField]
    private Canvas _canvas;
    [SerializeField]
    private Button _twoPlayers;
    [SerializeField]
    private Button _threePlayers;
    [SerializeField]
    private Button _fourPlayers;
    private Image _twoCols;
    private Image _threeCols;
    private Image _fourCols;

    void Start () {
        _cone = GetComponent<BeardCone>();
        _canvas.enabled = false;
        _twoCols = _twoPlayers.GetComponent<Image>();
        _threeCols = _threePlayers.GetComponent<Image>();
        _fourCols = _fourPlayers.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            _canvas.enabled = true;
            _cone.currentColour = currentPlayer;
            switch (currentPlayer)
            {
                case ("red"):
                    if (players == 2)
                    {
                        _nextPlayer = "blue";
                    }
                    else
                    {
                        _nextPlayer = "yellow";
                    }
                    break;
                case ("yellow"):
                    _nextPlayer = "blue";
                    break;
                case ("blue"):
                    if (players == 4)
                    {
                        _nextPlayer = "green";
                    }
                    else
                    {
                        _nextPlayer = "red";
                    }
                    break;
                case ("green"):
                    _nextPlayer = "red";
                    break;
                default:
                    _nextPlayer = "blue";
                    break;
            }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Main menu"))
        {
            switch (players)
            {
                case (2):
                    _twoCols.color = Color.green;
                    _threeCols.color = Color.white;
                    _fourCols.color = Color.white;
                    break;
                case (3):
                    _twoCols.color = Color.white;
                    _threeCols.color = Color.green;
                    _fourCols.color = Color.white;
                    break;
                case (4):
                    _twoCols.color = Color.white;
                    _threeCols.color = Color.white;
                    _fourCols.color = Color.green;
                    break;
            }
        }    
	}

    public void SetPlayers(int amount)
    {
        players = amount;
    }

    public void NextPlayer()
    {
        currentPlayer = _nextPlayer;
    }
}
