using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PatternEnd : MonoBehaviour
{
    public UnityEvent PatternComplete { get; private set; }

    void Awake()
    {
        PatternComplete = new UnityEvent();
    }

    void OnDestroy()
    {
        PatternComplete.Invoke();
    }
}
