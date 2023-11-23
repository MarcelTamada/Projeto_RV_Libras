using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SSLibrasToPark : MonoBehaviour
{
    private Vector3 playerPosition = new Vector3(3.418f, 0.643f, -6.8269f); // A posição desejada do jogador
    private Quaternion playerRotation = Quaternion.Euler(0, 41, 0); // A rotação desejada do jogador

    public void ChangeSceneAndRepositionPlayer()
    {
        // Troca para a cena desejada (no caso, cena 1)
        SceneManager.LoadScene(1);

        // Use o método SceneManager.sceneLoaded para garantir que a cena foi carregada antes de reposicionar o jogador.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1) // Certifique-se de que estamos na cena desejada
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
