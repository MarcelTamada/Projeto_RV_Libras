using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HangmanControllerteste : MonoBehaviour
{
    [SerializeField] private GameObject wordContainer;
    [SerializeField] private GameObject keyboardContainer;
    [SerializeField] private GameObject letterContainer;
    [SerializeField] private GameObject[] hangmanStages;
    [SerializeField] private GameObject letterButton;
    [SerializeField] private TextAsset possibleWordFile;

    private List<string> possibleWords;
    private string currentWord;
    private List<char> guessedLetters;
    private int currentHangmanStage;

    private Text wordText;

    void Start()
    {
        wordText = wordContainer.GetComponentInChildren<Text>();

        possibleWords = new List<string>(possibleWordFile.text.Split('\n').Select(word => word.Trim()));
        StartNewGame();
    }

    void StartNewGame()
    {
        guessedLetters = new List<char>();
        currentHangmanStage = 0;
        wordText.text = "";

        currentWord = possibleWords[Random.Range(0, possibleWords.Count)].ToUpper();
        UpdateWordDisplay();
    }

    void UpdateWordDisplay()
    {
        string displayWord = "";

        foreach (char letter in currentWord)
        {
            if (guessedLetters.Contains(letter))
            {
                displayWord += letter + " ";
            }
            else
            {
                displayWord += "_ ";
            }
        }

        wordText.text = displayWord;
    }

    public void LetterButtonClicked(string letter)
    {
        char guess = letter[0];
        if (!guessedLetters.Contains(guess))
        {
            guessedLetters.Add(guess);

            if (!currentWord.Contains(guess.ToString()))
            {
                currentHangmanStage++;
                hangmanStages[currentHangmanStage - 1].SetActive(true);
            }

            UpdateWordDisplay();

            if (guessedLetters.Count == currentWord.Distinct().Count())
            {
                // Player won
                Debug.Log("You won!");
                StartNewGame();
            }
            else if (currentHangmanStage == hangmanStages.Length)
            {
                // Player lost
                Debug.Log("You lost. The word was: " + currentWord);
                StartNewGame();
            }
        }
    }

    public void ResetGameButtonClicked()
    {
        foreach (var stage in hangmanStages)
        {
            stage.SetActive(false);
        }
        StartNewGame();
    }
}
