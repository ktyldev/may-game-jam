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
    private float _rollSensitivity;
    [SerializeField]
    private float _maxSlide;
    [SerializeField]
    [Range(0, 1)]
    private float _slideSensitivity;

    private PlayerInput _input;

    // Use this for initialization
    void Start()
    {
        _input = this.Find<PlayerInput>(GameTags.Input);
    }

    // Update is called once per frame
    void Update()
    {
        var targetPosition = new Vector3
        {
            x = _input.HorizontalAxis * _maxSlide,
            y = transform.position.y,
            z = transform.position.z
        };

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            _slideSensitivity);

        transform.rotation = Quaternion.Slerp(
            transform.rotation, 
            _input.HorizontalRotation(_maxAngle), 
            _rollSensitivity);
    }
}
