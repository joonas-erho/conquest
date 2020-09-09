using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraMovementSpeed;
    public float cameraZoomSpeed;

    public float positionCorrectionSpeed;

    private float minMovementSpeed = 0.015f;
    private float maxMovementSpeed = 0.042f;

    public float maxZoom;
    public float minZoom;

    private float middleHeight;
    public float currentHeightOnScreen;

    public Camera cam;

    private Vector3 oldPosition;

    private void Start()
    {
        middleHeight = MatchManager.Singleton.mapHeight * 0.75f / 2f;

        //Set the camera to be in the center of the map
        Vector3 position = transform.position;
        position.y = middleHeight;
        transform.position = position;
    }

    void Update()
    {
        currentHeightOnScreen = (transform.position.z * -1f - 3f) * 1.5f + 5f;

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 position = transform.position;
            position[0] = position[0] - cameraMovementSpeed;
            transform.position = position;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 position = transform.position;
            position[0] = position[0] + cameraMovementSpeed;
            transform.position = position;
        }

        if (Input.GetKey(KeyCode.W) && transform.position.y < (MatchManager.Singleton.mapHeight * 0.75f - (currentHeightOnScreen / 2) * 0.75f))
        {
            Vector3 position = transform.position;
            position[1] = position[1] + cameraMovementSpeed;
            transform.position = position;
        }

        if (Input.GetKey(KeyCode.S) && transform.position.y > (-0.75f + (currentHeightOnScreen / 2) * 0.75f))
        {
            Vector3 position = transform.position;
            position[1] = position[1] - cameraMovementSpeed;
            transform.position = position;
        }

        if (Input.mouseScrollDelta.y < 0 && currentHeightOnScreen < MatchManager.Singleton.mapHeight)
        {
            Vector3 position = transform.position;
            position[2] = position[2] - cameraZoomSpeed;
            
            cameraMovementSpeed += 0.001f;

            if (transform.position.y < (-0.75f + (currentHeightOnScreen / 2) * 0.75f))
            {
                position[1] = position[1] + positionCorrectionSpeed;
            }
            else if (transform.position.y > (MatchManager.Singleton.mapHeight * 0.75f - (currentHeightOnScreen / 2) * 0.75f))
            {
                position[1] = position[1] - positionCorrectionSpeed;
            }

            transform.position = position;
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            Vector3 position = transform.position;
            position[2] = position[2] + cameraZoomSpeed;
            transform.position = position;
            cameraMovementSpeed -= 0.001f;
        }

        Clamp();

        CheckIfCameraMoved();
    }
    void CheckIfCameraMoved()
    {
        if(oldPosition != this.transform.position)
        {
            oldPosition = this.transform.position;

            for (int c = 0; c < MatchManager.Singleton.mapWidth; c++)
            {
                for (int r = 0; r < MatchManager.Singleton.mapHeight; r++)
                {
                    Tile tile = MatchManager.Singleton.GetTile(c, r);
                    TileMethods.UpdatePosition(tile, cam);
                }
            }
        }
    }

    void Clamp()
    {
        Vector3 position = transform.position;
        if (position.z > maxZoom) position.z = maxZoom;
        if (position.z < minZoom) position.z = minZoom;
        if (cameraMovementSpeed < minMovementSpeed) cameraMovementSpeed = minMovementSpeed;
        if (cameraMovementSpeed > maxMovementSpeed) cameraMovementSpeed = maxMovementSpeed;

        transform.position = position;
    }
}
