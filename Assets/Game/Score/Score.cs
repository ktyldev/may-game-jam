using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extensions;

public class Score : MonoBehaviour
{
    private int _score = 0;
    private int _scoreMultiplier = 1;
    private UI_Controller ui;

    private ShipMovement _ship;

    // Use this for initialization
    void Start ()
    {
        _ship = this.Find<ShipMovement>(GameTags.Player);
        InvokeRepeating("AddToScore", 0.0f, 0.5f);
        ui = this.Find(GameTags.IG_GUI).GetComponent<UI_Controller>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        ui.UpdateScore(_score, _scoreMultiplier);
	}

    public int ScoreValue
    {
        get
        {
            return _score;
        }
    }

    public void IncrementScoreMultiplier()
    {
        _scoreMultiplier++;
    }
    
    private void AddToScore()
    {
        _score += 1 * _scoreMultiplier;
    }
}
