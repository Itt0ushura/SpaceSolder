using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rb;
    private Vector2 _dragDirection;

    public float _movementSpeed;

    public InputActionReference MoveReference;

    private void OnEnable()
    {
        MoveReference.action.Enable();
    }

    private void OnDisable()
    {
        MoveReference.action.Disable();
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _dragDirection = MoveReference.action.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 newPosition = _rb.position + new Vector3(_dragDirection.x * _movementSpeed, 0f, _dragDirection.y * _movementSpeed) * Time.fixedDeltaTime;
        _rb.MovePosition(newPosition);
    }
}
