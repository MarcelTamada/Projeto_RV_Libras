using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SSLibras : MonoBehaviour
{
    private Vector3 playerPosition = new Vector3(-0.515f, -0.294f, -36.086f); // A posição desejada do jogador
    private Quaternion playerRotation = Quaternion.Euler(-8.5f, 10.85f, 0f); // A rotação desejada do jogador

    public void ChangeSceneAndRepositionPlayer()
    {
        // Use o método SceneManager.sceneLoaded para garantir que a cena foi carregada antes de reposicionar o jogador.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(2);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0) // Certifique-se de que estamos na cena desejada
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = playerPosition;
                player.transform.rotation = playerRotation; // Aplica a rotação
            }
            else
            {
                Debug.LogWarning("Player não encontrado na cena.");
            }

            // Remova o evento para evitar chamadas repetidas
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
