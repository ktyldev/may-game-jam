using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroy : MonoBehaviour
{
    [SerializeField]
    private float _minZ;
    
    void Update()
    {
        if (transform.position.z < _minZ)
        {
            Destroy(gameObject);
        }
    }
}
