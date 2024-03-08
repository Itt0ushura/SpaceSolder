using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject redDot;
    [SerializeField] private GameObject flash;
    [SerializeField] private GameObject decal;

    private bool _ray;
    private bool _isShooting;

    private RaycastHit _hit;

    void Start()
    {
        flash.SetActive(false);
    }

    void FixedUpdate()
    {
        _isShooting = false;
        flash.SetActive(_isShooting);
        Vector3 fwd = transform.TransformDirection(Vector3.up);
        _ray = Physics.Raycast(transform.position, fwd, out _hit);
        TargetLock();
    }
    public void Shoot()
    {
        _isShooting = true;
        flash.SetActive(_isShooting);
        if (_ray)
            Instantiate(decal, _hit.point, _hit.transform.rotation);
    }

    private void TargetLock()
    {
        if (_ray)
        {
            redDot.SetActive(true);
            redDot.transform.position = _hit.point;
        }
        else
        {
            redDot.SetActive(false);
        }
    }
}
