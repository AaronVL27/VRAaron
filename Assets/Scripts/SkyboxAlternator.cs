using System.Collections;
using UnityEngine;

public class SkyboxAlternator : MonoBehaviour
{
    [Header("Skybox Materials")]
    public Material skyboxOne;
    public Material skyboxTwo;

    public ParticleSystem RainSkyBoxOne;

    [Header("Settings")]
    public float changeIntervalSeconds = 10f; // Tiempo de espera en segundos

    void Start()
    {
        // Verifica que ambos materiales estén asignados antes de iniciar
        if (skyboxOne != null && skyboxTwo != null)
        {
            StartCoroutine(AlternatingSkyboxRoutine());
        }
        else
        {
            Debug.LogError("Por favor, asigna ambos materiales de Skybox en el Inspector.");
        }
    }

    IEnumerator AlternatingSkyboxRoutine()
    {
        // Variable para controlar cuál skybox está activo (true = Skybox 1, false = Skybox 2)
        bool isSkyboxOneActive = true;

        while (true)
        {
            // Elige el material dependiendo del estado del booleano
            Material targetSkybox;

            if (isSkyboxOneActive)
            {
                targetSkybox = skyboxOne;
                RainSkyBoxOne.Stop();
            }
            else
            {
                targetSkybox = skyboxTwo;
                RainSkyBoxOne.Play();
            }    

            // Aplica el Skybox y actualiza la iluminación ambiental
            RenderSettings.skybox = targetSkybox;
            DynamicGI.UpdateEnvironment();

            // Invierte el booleano para el siguiente ciclo
            isSkyboxOneActive = !isSkyboxOneActive;

            // Espera el tiempo configurado antes de continuar el bucle
            yield return new WaitForSeconds(changeIntervalSeconds);
        }
    }
}
