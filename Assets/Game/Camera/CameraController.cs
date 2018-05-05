using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private float _maxAngle;

    [SerializeField]
    [Range(0, 1)]
    private float _sensitivity;

    private PlayerInput _input;

    // Use this for initialization
    void Start()
    {
        _input = this.Find<PlayerInput>(GameTags.Input);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(
            transform.rotation, 
            _input.HorizontalRotation(_maxAngle), 
            _sensitivity);
    }
}
