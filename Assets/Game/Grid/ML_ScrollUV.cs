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

    private PlayerInput _input;
    private Vector2 uvAnimationRate = new Vector2();
    Vector2 uvOffset = Vector2.zero;

    void Start()
    {
        _input = this.Find<PlayerInput>(GameTags.Input);
    }

    void Update()
    {
        var moveSpeed = 1;
        uvAnimationRate = new Vector2
        {
            x = _input.HorizontalAxis,
            y = moveSpeed
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
