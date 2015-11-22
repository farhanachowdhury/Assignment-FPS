using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

public class GameController : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES
    public Text scoreLabel;
    public Text lifeLabel;
    public Text gameOverLbl;

    // PRIVATE INSTANCE VARIABLES
    private int _scoreValue;
    private int _liveValue;
    private bool gameOver;
    private GameObject[] Player;

    // PUBLIC PROPERTIES
    public int Score
    {
        get
        {
            return _scoreValue;
        }
        set
        {
            _scoreValue = value;
           this._updateHUD();
        }
    }
    //life deduction for player
    public void DeductLife(int life)
    {
        this._liveValue -= life;
        if(this._liveValue<=0)
        {
            Destroy(Player[0]);
            this.gameOver = true;
            this.gameOverLbl.text = "You died.Press P to continue";
        }
        this._updateHUD();
    }

    public int Life
    {
        get
        {
            return _liveValue;
        }
        set
        {
            _liveValue = value;
           this._updateHUD();
        }
    }

    // Use this for initialization
    void Start()
    {
        this._scoreValue = 0;
        this._liveValue = 5;
       this._updateHUD();
       this.gameOver = false;
       Player = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameOver)
        {
           // if (CrossPlatformInputManager.GetButton("P"))
            if (Input.GetKeyDown(KeyCode.P))
            {
                Application.LoadLevel(Application.loadedLevel);
                this.gameOver = false;
            }
        }
    }

    // PRIVATE METHODS
    private void _updateHUD()
    {
        this.scoreLabel.text = "Score: " + this._scoreValue;
        this.lifeLabel.text = "Life: " + this._liveValue;
    }
}
