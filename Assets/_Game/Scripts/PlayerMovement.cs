using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rb;

    private Vector2 _dragDirection;
    private Quaternion _startRotation;

    private Vector3 newPosition;
    public float _movementSpeed;

    public InputActionReference MoveReference;

    //for the future(maybe) improvements
    int isWalkingHash;
    bool isWalking;

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
        _animator = GetComponent<Animator>();
        //isWalkingHash = Animator.StringToHash("isWalking");
    }

    private void FixedUpdate()
    {
        //isWalking = _animator.GetBool(isWalkingHash);
        _dragDirection = MoveReference.action.ReadValue<Vector2>();
        Movement();
        DirectionCheck();
    }

    private void DirectionCheck()
    {
        if (_dragDirection != Vector2.zero)
        {
            var dir = new Vector3(_dragDirection.x, 0f, _dragDirection.y);

            var targetRotation = _startRotation * Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.1f);
        }
        _startRotation = Quaternion.Slerp(_startRotation, transform.rotation, 0.02f);
    }

    private void Movement()
    {
        if (_dragDirection.magnitude > 0.4)
        {
            _animator.SetBool("isWalking", true);

            newPosition = _rb.transform.forward * _movementSpeed * _dragDirection.magnitude;

            _rb.velocity = newPosition;
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }
}