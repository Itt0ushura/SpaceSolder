using UnityEngine;

public class DecalBehaviour : MonoBehaviour
{
    [SerializeField] private float deletionTime;
    private void OnEnable()
    {
        Destroy(gameObject, deletionTime);
    }
}
