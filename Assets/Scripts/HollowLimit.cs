using UnityEngine;
using UnityEngine.SceneManagement;

public class HollowLimit : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        ReiniciarEscena();
    }

    public void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
