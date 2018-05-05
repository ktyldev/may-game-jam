using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    /// <summary>
    /// Get the horizontal axis provided by player input
    /// </summary>
    public float HorizontalAxis
    {
        get
        {
            return Input.GetAxis(GameTags.Horizontal);
        }
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
