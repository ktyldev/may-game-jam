using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField]
    private float _forwardMoveSpeed;
    public float ForwardMoveSpeed { get { return _forwardMoveSpeed; } }

    [SerializeField]
    private float _horizontalMoveSpeed;
    public float HorizontalMoveSpeed { get { return _horizontalMoveSpeed * _input.HorizontalAxis; } }

    public Vector2 Velocity
    {
        get
        {
            return new Vector2
            {
                x = HorizontalMoveSpeed,
                y = ForwardMoveSpeed
            };
        }
    }

    private PlayerInput _input;

    // Use this for initialization
    void Start()
    {
        _input = this.Find<PlayerInput>(GameTags.Input);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
