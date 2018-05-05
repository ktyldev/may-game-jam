using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1)]
    private float _damping;

    /// <summary>
    /// Get the horizontal axis provided by player input
    /// </summary>
    public float HorizontalAxis
    {
        get
        {
            return _current;
        }
    }

    private float _current;

    private void Update()
    {
        _current = Mathf.Lerp(_current, Input.GetAxis(GameTags.Horizontal), _damping);
    }

    /// <summary>
    /// Get a rotation around the forward axis based on a maximum angle
    /// </summary>
    /// <param name="maxAngle"></param>
    /// <returns></returns>
    public Quaternion HorizontalRotation(float maxAngle)
    {
        return Quaternion.AngleAxis(maxAngle * -HorizontalAxis, Vector3.forward);
    }
}
