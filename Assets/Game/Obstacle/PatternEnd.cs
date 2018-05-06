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

    void Awake()
    {
        PatternComplete = new UnityEvent();
        _ship = this.Find<ShipMovement>(GameTags.Player);
        _score = this.Find<Score>(GameTags.Score);
    }

    void OnDestroy()
    {
        _score.IncrementScoreMultiplier();
        _ship.IncrementSpeed();
        PatternComplete.Invoke();
    }
}
