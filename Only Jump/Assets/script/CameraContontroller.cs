using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float minFov = 15f;
    public float maxFov = 90f;
    public float sensitivity = 10f;

    private Camera cameraComponent;

    private void Start()
    {
        cameraComponent = GetComponent<Camera>();
    }

    private void Update()
    {
        float fov = cameraComponent.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        cameraComponent.fieldOfView = fov;
    }
}