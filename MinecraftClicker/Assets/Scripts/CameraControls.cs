using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private Vector3 cameraPosition;
    
    [Header("Camera Settings")]
    private float cameraSpeed = 1.0f;
    private float zoom;
    private float zoomMultiplier = 50.0f;
    private float minZoom = 5.0f;
    private float maxZoom = 100.0f;
    private float velocity = 0.0f;
    private float smoothTime = 0.25f;

    [SerializeField] SpriteRenderer mapRenderer;
    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    private void Awake()
    {
        mapMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;
        
        mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;
    }

    // Start is called before the first frame update
    void Start()
    {
        // this.transform.position = new Vector3( (float) width/2 - 0.5f, (float) height/2 - 0.5f, -10);
        this.transform.position = new Vector3( 340, 155, -10); // may change due to difficulty
        cameraPosition = this.transform.position;

        zoom = cam.orthographicSize;
        zoom = 20;
    }

    // Update is called once per frame
    void Update()
    {
        // scrolling
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);

        // directional
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            cameraPosition.y += cameraSpeed / (maxZoom/zoom);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            cameraPosition.y -= cameraSpeed / (maxZoom/zoom);
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            cameraPosition.x -= cameraSpeed / (maxZoom/zoom);
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            cameraPosition.x += cameraSpeed / (maxZoom/zoom);
        }
        this.transform.position = ClampCamera(cameraPosition);
        cameraPosition = this.transform.position;
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = mapMinX - 100 + camWidth;
        float maxX = mapMaxX + 100 - camWidth;
        float minY = mapMinY - 100 + camHeight;
        float maxY = mapMaxY + 100 - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }
}
