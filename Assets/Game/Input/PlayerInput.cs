using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float HorizontalAxis
    {
        get
        {
            return Input.GetAxis("Horizontal");
        }
    }

    void Update()
    {
        print(HorizontalAxis);
    }
}
