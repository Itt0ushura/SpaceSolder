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

    private void Update()
    {
        //isWalking = _animator.GetBool(isWalkingHash);

        _dragDirection = MoveReference.action.ReadValue<Vector2>();

        DirectionCheck();

    }

    private void FixedUpdate()
    {

        Movement();

    }

    private void DirectionCheck()
    {

        if (_dragDirection != Vector2.zero)
        {

            var dir = new Vector3(_dragDirection.x, 0f, _dragDirection.y);
            transform.rotation = Quaternion.LookRotation(dir);

        }

    }

    private void Movement()
    {
        if (_dragDirection.magnitude > 0.4)
        {
            _animator.SetBool("isWalking", true);

            newPosition = /*_rb.position + */_rb.transform.forward * _movementSpeed * _dragDirection.magnitude;
            //_rb.MovePosition(newPosition);
            _rb.velocity = newPosition;

        }
        else
        {

            _animator.SetBool("isWalking", false);

        }        
    }
}