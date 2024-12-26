using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0f, 3f, -15f);  // Adjust this for the camera's position
    public float smoothSpeed = 0.125f;
    public Camera mainCamera;
    public float desiredOrthographicSize = 7f;  // Adjust this for zoom level (larger is more zoomed out)
    public float zoomSpeed = 2f;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        if (mainCamera.orthographic)
        {
            float currentSize = mainCamera.orthographicSize;
            float targetSize = Mathf.Lerp(currentSize, desiredOrthographicSize, Time.deltaTime * zoomSpeed);
            mainCamera.orthographicSize = targetSize;
        }
    }
}
