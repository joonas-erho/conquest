using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraController : MonoBehaviour
{
    private int mapWidth;
    private int mapHeight;

    public Camera minimapCamera;

    public RenderTexture renderTexture;

    void Start()
    {       
        mapWidth = MatchManager.Singleton.mapWidth;
        mapHeight = MatchManager.Singleton.mapHeight;
        float y = (mapHeight * 0.75f - 0.375f) / 2f;
        Vector3 position = new Vector3 (0f, y, -10f);
        minimapCamera.transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
