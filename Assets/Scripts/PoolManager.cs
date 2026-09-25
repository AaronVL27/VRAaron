using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    [SerializeField]Transform container;
    [SerializeField]Transform container2;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject Bullet2;
    [SerializeField] private int cantidadInicial = 10;

    private Queue<GameObject> pool = new Queue<GameObject>();
    private Queue<GameObject> pool2 = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < cantidadInicial; i++)
        {
            GameObject obj = Instantiate(Bullet, container);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }

        for (int i = 0; i < cantidadInicial; i++)
        {
            GameObject obj = Instantiate(Bullet2, container2);
            obj.SetActive(false);
            pool2.Enqueue(obj);
        }
    }

    public GameObject ObtenerObjeto()
    {
        GameObject obj = pool.Count > 0 ? pool.Dequeue() : Instantiate(Bullet, container);
        //obj.SetActive(true);
        return obj;
    }

    public GameObject ObtenerObjeto2()
    {
        GameObject obj = pool2.Count > 0 ? pool2.Dequeue() : Instantiate(Bullet2, container2);
        //obj.SetActive(true);
        return obj;
    }

    public void DevolverObjeto(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }

    public void DevolverObjeto2(GameObject obj)
    {
        obj.SetActive(false);
        pool2.Enqueue(obj);
    }

}
