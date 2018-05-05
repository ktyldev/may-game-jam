using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ML_ScrollUV : MonoBehaviour
{
    // Update is called once per frame
    public int materialIndex = 0;
    public string textureName = "_MainTex";
    public Renderer render;

    private Vector2 uvAnimationRate = new Vector2();
    private Vector2 uvOffset = Vector2.zero;
    
    private ShipMovement _ship;

    void Start()
    {
        _ship = this.Find<ShipMovement>(GameTags.Player);
    }

    void Update()
    {
        uvAnimationRate = new Vector2
        {
            x = _ship.HorizontalMoveSpeed,
            y = _ship.ForwardMoveSpeed
        };
    }

    void LateUpdate()
    {
        uvOffset += (uvAnimationRate * Time.deltaTime);
        if (render.enabled)
        {
            render.materials[materialIndex].SetTextureOffset(textureName, uvOffset);
        }
    }
}
