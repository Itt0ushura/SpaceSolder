using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rb;
    
    public float _movementSpeed;
    
    private Vector2 _dragDirection;

    public InputActionReference MoveReference;

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
        OnPlayerMove();
    }

    private void OnPlayerMove()
    {
        _rb.velocity = new Vector3(_dragDirection.x * _movementSpeed, 0f, _dragDirection.y * _movementSpeed);
    }
}
