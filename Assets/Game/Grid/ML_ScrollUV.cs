using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ML_ScrollUV : MonoBehaviour {
    // Update is called once per frame
    public int materialIndex = 0;
    public Vector2 uvAnimationRate = new Vector2(1.0f, 0.0f);
    public string textureName = "_MainTex";
    public Renderer render;

    Vector2 uvOffset = Vector2.zero;
    void LateUpdate () {
        uvOffset += (uvAnimationRate * Time.deltaTime);
        if (render.enabled)
        {
            render.materials[materialIndex].SetTextureOffset(textureName, uvOffset);
        }
	}
}
