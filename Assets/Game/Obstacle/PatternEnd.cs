using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PatternEnd : MonoBehaviour
{
    public UnityEvent PatternComplete { get; private set; }

    private ShipMovement _ship;
    private Score _score;
    private UI_Controller _ui;

    void Awake()
    {
        PatternComplete = new UnityEvent();
        _ship = this.Find<ShipMovement>(GameTags.Player);
        _score = this.Find<Score>(GameTags.Score);
        _ui = this.Find<UI_Controller>(GameTags.IG_GUI);
    }

    void OnDestroy()
    {
        _score.IncrementScoreMultiplier();
        _ship.IncrementSpeed();
        _ui.DisplayStage(true);
        PatternComplete.Invoke();
    }
}
