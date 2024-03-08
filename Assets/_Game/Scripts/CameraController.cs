using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] private Transform playerTransform;

    [Space]
    [SerializeField] private Vector3 cameraOffset;

    void Start()
    {
        _camera = Camera.main;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = playerTransform.position + playerTransform.right * cameraOffset.x + playerTransform.up * cameraOffset.y - playerTransform.forward * cameraOffset.z;

        _camera.transform.position = Vector3.Lerp(_camera.transform.position, targetPosition, 0.5f);

        _camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation, playerTransform.transform.rotation, 0.6f);
    }
}