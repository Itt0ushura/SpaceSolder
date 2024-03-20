using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject redDot;
    [SerializeField] private GameObject flash;
    [SerializeField] private GameObject decal;

    private bool _ray;

    private RaycastHit _hit;

    void Start()
    {
        flash.SetActive(false);
    }

    void FixedUpdate()
    {
        flash.SetActive(false);
        Vector3 fwd = transform.TransformDirection(Vector3.up);
        _ray = Physics.Raycast(transform.position, fwd, out _hit);
        TargetLock();
    }
    public void Shoot()
    {
        flash.SetActive(true);
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
