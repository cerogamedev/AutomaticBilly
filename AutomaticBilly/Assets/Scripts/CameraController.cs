using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float smoothing = 5f;     // How smoothly the camera follows the targets
    public Vector3 offset;           // The camera's position relative to the targets
    public string targetTag;         // The tag shared by all the targets to follow
    public float zoomSpeed = 2f;     // How quickly the camera zooms in and out
    public float minZoom = 5f;       // The minimum zoom level
    public float maxZoom = 15f;      // The maximum zoom level

    private Transform[] targets;     // The array of target transforms to follow
    private Vector3 targetPosition;  // The position the camera is moving towards
    private float targetZoom;        // The zoom level the camera is moving towards

    void Start()
    {
        // Find all objects with the target tag and add their transforms to the array
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);
        targets = new Transform[targetObjects.Length];
        for (int i = 0; i < targetObjects.Length; i++)
        {
            targets[i] = targetObjects[i].transform;
        }

        // Set the initial zoom level to the middle of the min-max range
        targetZoom = (minZoom + maxZoom) / 2f;
    }

    void LateUpdate()
    {
        // If there are no targets, do nothing
        if (targets.Length == 0)
        {
            return;
        }

        // Calculate the average position of all the targets
        Vector3 averagePosition = Vector3.zero;
        for (int i = 0; i < targets.Length; i++)
        {
            averagePosition += targets[i].position;
        }
        averagePosition /= targets.Length;

        // Move the camera towards the average position of the targets with offset
        targetPosition = averagePosition + offset * targetZoom;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);

        // Zoom the camera in and out based on the scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        targetZoom = Mathf.Clamp(targetZoom - scroll * zoomSpeed, minZoom, maxZoom);
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetZoom, smoothing * Time.deltaTime);
    }
}
