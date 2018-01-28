using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    public Transform player1;
    public Transform player2;

    private List<Transform> objects = new List<Transform>();

    private const float DISTANCE_MARGIN = 1.0f;

    private Vector3 middlePoint;
    private float distanceFromMiddlePoint;
    private float distanceBetweenPlayers;
    private float cameraDistance;
    private float aspectRatio;
    private float fov;
    private float tanFov;

    void Start()
    {
        aspectRatio = Screen.width / Screen.height;
        tanFov = Mathf.Tan(Mathf.Deg2Rad * Camera.main.fieldOfView / 2.0f);
    }

    void Update()
    {
        // Position the camera in the center.
        Vector3 newCameraPos = Camera.main.transform.position;
        newCameraPos.x = middlePoint.x;
        Camera.main.transform.position = newCameraPos;

        Vector3 center = new Vector3(0, 0, 0);
        float count = 0;

        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            center += go.transform.position;
            count++;
        }

        Vector3 theCenter = center / count;

        // Calculate the new distance.
        distanceBetweenPlayers = theCenter.magnitude;
        cameraDistance = (distanceBetweenPlayers / 2.0f / aspectRatio) / tanFov;

        // Set camera to new position.
        Vector3 dir = (Camera.main.transform.position - middlePoint).normalized;
        Camera.main.transform.position = middlePoint + dir * (cameraDistance + DISTANCE_MARGIN);
    }


}
