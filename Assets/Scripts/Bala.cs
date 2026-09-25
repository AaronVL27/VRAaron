using System;
using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody rb;


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("La bala chocó con: " + collision.gameObject.name);
        PoolManager.Instance.DevolverObjeto(gameObject);
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        StartCoroutine(BulletCoodown());
    }
    private void OnDisable()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
    IEnumerator BulletCoodown()
    {
        yield return new WaitForSeconds(2);
        PoolManager.Instance.DevolverObjeto(gameObject);
    }
}
