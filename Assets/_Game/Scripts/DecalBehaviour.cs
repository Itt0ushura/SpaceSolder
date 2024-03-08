using System.Collections;
using UnityEngine;

public class DecalBehaviour : MonoBehaviour
{
    [SerializeField] private float deletionTime;
    private IEnumerator a;
    private void OnEnable()
    {
        a = VanishCooldown(deletionTime);
        StartCoroutine(a);
    }
    private void OnDisable()
    {
        StopCoroutine(a);
    }

    private IEnumerator VanishCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
