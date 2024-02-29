using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rb;
    private Vector2 _dragDirection;
    Vector3 newPosition;
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

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _dragDirection = MoveReference.action.ReadValue<Vector2>();
        if(_dragDirection != Vector2.zero)
        {
            transform.forward = new Vector3(_dragDirection.x, 0f, _dragDirection.y);
        }
        newPosition = _rb.position + _rb.transform.forward * _movementSpeed * _dragDirection.magnitude * Time.fixedDeltaTime;   
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(newPosition);
    }
}