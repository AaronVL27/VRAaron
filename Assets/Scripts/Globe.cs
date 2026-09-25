using System.Collections;
using UnityEngine;

public class Globe : MonoBehaviour
{
    [SerializeField] ParticleSystem boom;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala") || collision.gameObject.CompareTag("Dardo"))
        {
            boom.Play();
            StartCoroutine(CoolDownBoom());
        }
    }
    IEnumerator CoolDownBoom()
    {
        yield return new WaitForSeconds(0.06f);
        Destroy(gameObject);
    }
}