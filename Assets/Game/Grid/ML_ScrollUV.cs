using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ML_ScrollUV : MonoBehaviour
{
    // Update is called once per frame
    public int materialIndex = 0;
    public string textureName = "_MainTex";
    public Renderer render;

    private Vector2 uvAnimationRate = new Vector2();
    private Vector2 uvOffset = Vector2.zero;
    
    private ShipMovement _ship;

    private bool _mainMenu;

    private void Awake()
    {
        _mainMenu = SceneManager.GetActiveScene().name == "Menu_Main";
    }

    void Start()
    {
        if (_mainMenu)
            return;

        _ship = this.Find<ShipMovement>(GameTags.Player);
    }

    void Update()
    {
        if (_mainMenu)
            return;

        uvAnimationRate = _ship.Velocity;
    }

    void LateUpdate()
    {
        if (_mainMenu)
            return;

        uvOffset += (uvAnimationRate * Time.deltaTime);
        if (render.enabled)
        {
            render.materials[materialIndex].SetTextureOffset(textureName, uvOffset);
        }
    }
}
