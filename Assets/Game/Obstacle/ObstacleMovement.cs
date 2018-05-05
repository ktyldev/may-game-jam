using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private ShipMovement _ship;

    // Use this for initialization
    void Start()
    {
        _ship = this.Find<ShipMovement>(GameTags.Player);
    }

    // Update is called once per frame
    void Update()
    {
        // Hacky hack :)
        if (Time.timeScale == 0)
            return;

        var moveDir = -_ship.Velocity3D;
        // Not actually sure why this is necessary but it seems to work?????
        moveDir.x /= 2;

        transform.Translate(moveDir);
    }
}
