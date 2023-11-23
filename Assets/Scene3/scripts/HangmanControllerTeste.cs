using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class HangmanControllerTeste : MonoBehaviour
{
    [SerializeField] GameObject wordContainer;
    [SerializeField] GameObject keyboardContainer;
    [SerializeField] GameObject letterContainer;
    [SerializeField] GameObject[] hangmanStages;
    [SerializeField] GameObject letterButton;
    [SerializeField] TextAsset possibleWord;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private string videoFolderPath = "E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/Cores";

    private string word;
    private int incorrectGuesses, correctGuesses;
    private bool isGameWaiting;

    void Start()
    {
        InitialiseButtons();
        InitialiseGame();
    }

    private void InitialiseButtons()
    {
        for (int i = 65; i <= 90; i++)
        {
            CreateButton(i);
        }
    }

    private void InitialiseGame()
    {
        // Reseta o jogo para o estado original
        incorrectGuesses = 0;
        correctGuesses = 0;
        SetKeyboardContainerInteractable(true); // Torna o keyboardContainer interagível
        foreach(Transform child in wordContainer.GetComponentInChildren<Transform>())
        {
            Destroy(child.gameObject);
        }
        foreach(GameObject stage in hangmanStages)
        {
            stage.SetActive(false);
        }

        // Gera uma nova palavra
        word = GenerateWord().ToUpper();
        foreach (char letter in word)
        {
            var temp = Instantiate(letterContainer, wordContainer.transform);
        }
    }

    private void SetKeyboardContainerInteractable(bool interactable)
    {
        foreach (Button button in keyboardContainer.GetComponentsInChildren<Button>())
        {
            button.interactable = interactable;
        }
    }

    private void CreateButton(int i)
    {
        GameObject temp = Instantiate(letterButton, keyboardContainer.transform);
        temp.GetComponentInChildren<TextMeshProUGUI>().text = ((char)i).ToString();
        temp.GetComponent<Button>().onClick.AddListener(delegate { CheckLetter(((char)i).ToString()); });
    }

    private string GenerateWord()
    {
        string[] wordList = possibleWord.text.Split('\n');
        string line = wordList[Random.Range(0, wordList.Length - 1)];
        return line.Substring(0, line.Length - 1);
    }

    private void CheckLetter(string inputLetter)
    {
        bool letterInWord = false;
        for (int i = 0; i < word.Length; i++)
        {
            if (inputLetter == word[i].ToString())
            {
                letterInWord = true;
                correctGuesses++;
                wordContainer.GetComponentsInChildren<TextMeshProUGUI>()[i].text = inputLetter;
            }
        }

        if (letterInWord == false)
        {
            incorrectGuesses++;
            hangmanStages[incorrectGuesses - 1].SetActive(true);
        }
        CheckOutcome();
    }

    private void CheckOutcome()
    {
        if (correctGuesses == word.Length) // Venceu!
        {
            for (int i = 0; i < word.Length; i++)
            {
                wordContainer.GetComponentsInChildren<TextMeshProUGUI>()[i].color = Color.green;
            }
            PlayVideo(word);
            isGameWaiting = true;
            SetKeyboardContainerInteractable(false); // Desativa o keyboardContainer durante o atraso
            StartCoroutine(StartNewGameAfterDelay(5f)); // Delay para iniciar o próximo jogo
        }

        if (incorrectGuesses == hangmanStages.Length) // Derrota!
        {
            for (int i = 0; i<word.Length;i++)
            {
                wordContainer.GetComponentsInChildren<TextMeshProUGUI>()[i].color = Color.red;
                wordContainer.GetComponentsInChildren<TextMeshProUGUI>()[i].text = word[i].ToString();
            }
            PlayVideoFile("/ERRO.mp4");
            isGameWaiting = true;
            SetKeyboardContainerInteractable(false); // Desativa o keyboardContainer durante o atraso
            StartCoroutine(StartNewGameAfterDelay(5f)); // Delay para iniciar o próximo jogo
        }
    }

    private IEnumerator StartNewGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isGameWaiting = false; // O jogo não está mais em espera.
        SetKeyboardContainerInteractable(true); // Torna o keyboardContainer interagível novamente
        InitialiseGame(); // Inicia um novo jogo.
    }

    public void PlayVideo(string word)
    {
        // Converte a palavra para letras maiúsculas para garantir a correspondência.
        string wor = word.ToUpper();

        if (wor == "VERMELHO")
        {
            PlayVideoFile("/VERMELHO.mp4");
        }
        else if (wor == "AZUL")
        {
            PlayVideoFile("/AZUL.mp4");
        }
        else if (wor == "VERDE")
        {
            PlayVideoFile("/VERDE.mp4");
        }
        else if (wor == "AMARELO")
        {
            PlayVideoFile("/AMARELO.mp4");
        }
        else if (wor == "ROXO")
        {
            PlayVideoFile("/ROXO.mp4");
        }
        else if (wor == "LARANJA")
        {
            PlayVideoFile("/LARANJA.mp4");
        }
        else if (wor == "ROSA")
        {
            PlayVideoFile("/ROSA.mp4");
        }
        else if (wor == "PRETO")
        {
            PlayVideoFile("/PRETO.mp4");
        }
        else if (wor == "BRANCO")
        {
            PlayVideoFile("/BRANCO.mp4");
        }
        else if (wor == "CINZA")
        {
            PlayVideoFile("/CINZA.mp4");
        }
        else
        {
            Debug.LogWarning("Palavra não reconhecida: " + wor);
        }
    }

    private void PlayVideoFile(string videoFileName)
    {
        string videoPath = videoFolderPath + videoFileName;
        videoPlayer.url = videoPath;
        videoPlayer.Play();
    }
}
