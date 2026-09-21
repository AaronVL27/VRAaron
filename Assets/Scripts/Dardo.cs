using UnityEngine;

public class Dardo : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Diana"))
        {
            //rb.isKinematic = true; El problema ocurre porque al activar rb.isKinematic = true, el sistema de física de Unity interrumpe inmediatamente el contacto entre las superficies. Esto provoca que Unity ejecute automáticamente el evento OnCollisionExit, el cual vuelve a desactivar isKinematic, creando un bucle infinito entre la entrada y la salida de la colisión.
            rb.useGravity = false;
            rb.linearVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeRotation;

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Diana"))
        {
            //rb.isKinematic = false;
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}