using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private bool _mainMenu;

    private void Awake()
    {
        _mainMenu = SceneManager.GetActiveScene().name == "Menu_Main";
    }

    // Use this for initialization
    void Start()
    {
        if (_mainMenu)
            return;

        _input = this.Find<PlayerInput>(GameTags.Input);
    }

    // Update is called once per frame
    void Update()
    {
        if (_mainMenu)
            return;

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
