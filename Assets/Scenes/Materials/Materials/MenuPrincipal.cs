using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuPrincipal : MonoBehaviour
{
    public Button botaoJogar;
    public Button botaoOpcoes;
    public Button botaoSair;

    void Start()
    {
        // Adicionar listeners aos botões
        botaoJogar.onClick.AddListener(IniciarJogo);
        botaoOpcoes.onClick.AddListener(AbrirOpcoes);
        botaoSair.onClick.AddListener(SairDoJogo);
    }

    public void IniciarJogo()
    {
        // Carregar a cena do jogo (substitua "NomeDaSuaCena" pelo nome real da cena)
        SceneManager.LoadScene(1);
    }

    public void AbrirOpcoes()
    {
        // Implementar lógica para abrir o menu de opções
        Debug.Log("Abrindo menu de opções...");
    }

    public void SairDoJogo()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Pare a reprodução no Editor do Unity.
        #else
        Application.Quit(); // Feche o aplicativo. Isso só funcionará em builds executáveis.
        #endif
    }
}
