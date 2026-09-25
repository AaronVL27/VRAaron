using UnityEngine;

public class Arma : MonoBehaviour
{
    [SerializeField] private Transform pointShot;
    [SerializeField] private ParticleSystem ParticlesPointShot;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    [ContextMenu("Shot")]
    public void Shoot()
    {
        ParticlesPointShot.Play();

        GameObject bullet = PoolManager.Instance.ObtenerObjeto();
        bullet.transform.position = pointShot.position;
        bullet.transform.rotation = pointShot.rotation;
        bullet.SetActive(true);
    }
}
