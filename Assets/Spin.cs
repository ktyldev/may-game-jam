using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    float _rot = 0.5f;

	void Update ()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, 1), _rot);
	}
}
