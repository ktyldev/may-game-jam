using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extensions;

public class Score : MonoBehaviour
{
    private int _score = 0;
    private int _scoreMultipler = 1;
    private UI_Controller ui;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("AddToScore", 0.0f, 0.5f);
        ui = this.Find(GameTags.IG_GUI).GetComponent<UI_Controller>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        ui.UpdateScore(_score, _scoreMultipler);
	}

    public int ScoreValue
    {
        get
        {
            return _score;
        }
    }

    public int ScoreMultiplier
    {
        get
        {
            return _scoreMultipler;
        }
        set
        {
            _scoreMultipler = value;
        }
    }
    private void AddToScore()
    {
        _score += 1 * _scoreMultipler;
    }
}
