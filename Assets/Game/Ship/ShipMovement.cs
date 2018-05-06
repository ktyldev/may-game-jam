using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    [SerializeField]
    private float _forwardMoveSpeed;
    public float ForwardMoveSpeed { get { return _forwardMoveSpeed * SpeedMultiplier; } }
    
    [SerializeField]
    private float _horizontalMoveSpeed;
    public float HorizontalMoveSpeed { get { return _horizontalMoveSpeed * _input.HorizontalAxis * SpeedMultiplier; } }

    [SerializeField]
    private float _speedMultiplierIncrement;

    public float SpeedMultiplier { get; private set; }
    
    public Vector2 Velocity
    {
        get
        {
            return new Vector2
            {
                x = Velocity3D.x,
                y = Velocity3D.z
            };
        }
    }

    public Vector3 Velocity3D
    {
        get
        {
            return new Vector3
            {
                x = HorizontalMoveSpeed,
                z = ForwardMoveSpeed
            };
        }
    }

    private PlayerInput _input;
    
    void Start()
    {
        _input = this.Find<PlayerInput>(GameTags.Input);
        SpeedMultiplier = 1;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("Menu_Main");
        }
    }

    public void IncrementSpeed()
    {
        SpeedMultiplier += _speedMultiplierIncrement;
    }
}
