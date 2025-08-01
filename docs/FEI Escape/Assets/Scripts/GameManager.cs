using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    // Define the different states of the game
    public enum GameState
    {
        Gameplay,
        Paused,
        GameOver,
        LevelUp
    }

    // Store the current state of the game
    public GameState currentState;

    // Store the previous state of the game before it was paused
    public GameState previousState;

    [Header("Screens")]
    public GameObject pauseScreen;
    public GameObject resultsScreen;
    public GameObject passouFase1Screen;
    public GameObject levelUpScreen;


    [Header("Current Stat Displays")]
    public Text currentHealthDisplay;
    public Text currentRecoveryDisplay;
    public Text currentMoveSpeedDisplay;
    public Text currentMightDisplay;
    public Text currentProjectileSpeedDisplay;
    public Text currentMagnetDisplay;

    [Header("Results Screen Displays")]
    public Image chosenCharacterImage;
    public Text chosenCharacterName;
    public Text levelReachedDisplay;
    public List<Image> chosenWeaponsUI = new List<Image>(6);
    public List<Image> chosenPassiveItemsUI = new List<Image>(6);

    [Header("Stopwatch")]
    public float timeLimit; // The time limit in seconds
    float stopwatchTime; // The current time elapsed since the stopwatch started
    public Text stopwatchDisplay;

    // Flag to check if the game is over
    public bool isGameOver = false;
    public bool choosingUpgrade = false;
    void Awake()
    {
        //Warning check to see if there is another singleton of this kind already in the game
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("EXTRA " + this + " DELETED");
            Destroy(gameObject);
        }

        DisableScreens();
    }

    void Update()
    {
        // Define the behavior for each state
        switch (currentState)
        {
            case GameState.Gameplay:
                // Code for the gameplay state
                CheckForPauseAndResume();
                UpdateStopwatch();
                break;
            case GameState.Paused:
                // Code for the paused state
                CheckForPauseAndResume();
                break;
            case GameState.GameOver:
                // Code for the game over state
                if (!isGameOver)
                {
                    isGameOver = true;
                    Time.timeScale = 0f; //Stop the game entirely
                    Debug.Log("Game is over");
                    DisplayResults();
                }
                break;
            case GameState.LevelUp:
                if(!choosingUpgrade)
                {
                    levelUpScreen.SetActive(true);
                    choosingUpgrade = true;
                    Time.timeScale = 0f; //Pause the game for now
                    Debug.Log("Upgrades shown");
                    
                }
                break;
            default:
                Debug.LogWarning("STATE DOES NOT EXIST");
                break;
        }
    }

    // Define the method to change the state of the game
    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }

    public void PauseGame()
    {
        if (currentState != GameState.Paused)
        {
            previousState = currentState;
            ChangeState(GameState.Paused);
            Time.timeScale = 0f; // Stop the game
            pauseScreen.SetActive(true); // Enable the pause screen
            Debug.Log("Game is paused");
        }
    }

    public void ResumeGame()
    {
        if (currentState == GameState.Paused)
        {
            ChangeState(previousState);
            Time.timeScale = 1f; // Resume the game
            pauseScreen.SetActive(false); //Disable the pause screen
            Debug.Log("Game is resumed");
        }
    }

    // Define the method to check for pause and resume input
    void CheckForPauseAndResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void DisableScreens()
    {
        pauseScreen.SetActive(false);
        resultsScreen.SetActive(false);
        passouFase1Screen.SetActive(false);
        levelUpScreen.SetActive(false);
    }

    public void GameOver()
    {
        ChangeState(GameState.GameOver);
    }

    void DisplayResults()
    {
        resultsScreen.SetActive(true);
    }

    public void AssignLevelReachedUI(int levelReachedData)
    {
        levelReachedDisplay.text = levelReachedData.ToString();
    }

    public void AssignChosenWeaponsAndPassiveItemsUI(List<Image> chosenWeaponsData, List<Image> chosenPassiveItemsData)
    {
        // Check that both lists have the same length
        if (chosenWeaponsData.Count != chosenWeaponsUI.Count || chosenPassiveItemsData.Count != chosenPassiveItemsUI.Count)
        {
            Debug.LogError("Chosen weapons and passive items data lists have different lengths");
            return;
        }

        // Assign chosen weapons data to chosenWeaponsUI
        for (int i = 0; i < chosenWeaponsUI.Count; i++)
        {
            // Check that the sprite of the corresponding element in chosenWeaponsData is not null
            if (chosenWeaponsData[i].sprite)
            {
                // Enable the corresponding element in chosenWeaponsUI and set its sprite to the corresponding sprite in chosenWeaponsData
                chosenWeaponsUI[i].enabled = true;
                chosenWeaponsUI[i].sprite = chosenWeaponsData[i].sprite;
            }
            else
            {
                // If the sprite is null, disable the corresponding element in chosenWeaponsUI
                chosenWeaponsUI[i].enabled = false;
            }
        }

        // Assign chosen passive items data to chosenPassiveItemsUI
        for (int i = 0; i < chosenPassiveItemsUI.Count; i++)
        {
            // Check that the sprite of the corresponding element in chosenPassiveItemsData is not null
            if (chosenPassiveItemsData[i].sprite)
            {
                // Enable the corresponding element in chosenPassiveItemsUI and set its sprite to the corresponding sprite in chosenPassiveItemsData
                chosenPassiveItemsUI[i].enabled = true;
                chosenPassiveItemsUI[i].sprite = chosenPassiveItemsData[i].sprite;
            }
            else
            {
                // If the sprite is null, disable the corresponding element in chosenPassiveItemsUI
                chosenPassiveItemsUI[i].enabled = false;
            }
        }
    }

    void UpdateStopwatch()
    {
        stopwatchTime += Time.deltaTime;

        UpdateStopwatchDisplay();

        if (stopwatchTime >= timeLimit)
        {
            Time.timeScale = 0f;
            passouFase1Screen.SetActive(true);
            ChangeState(GameState.Paused);
            stopwatchTime = 0;
        }
        
    }

    void UpdateStopwatchDisplay()
    {
        // Calculate the number of minutes and seconds that have elapsed
        int minutes = Mathf.FloorToInt(stopwatchTime / 60);
        int seconds = Mathf.FloorToInt(stopwatchTime % 60);
        //stopwatchDisplay.text= ("Olá");
        // Update the stopwatch text to display the elapsed time
        stopwatchDisplay.text = $"{minutes:00}:{seconds:00} Sobreviva por 30 segundos";
    }
    public void StartLevelUp()
    {
        ChangeState(GameState.LevelUp);
    }

    public void EndLevelUp()
    {
        choosingUpgrade = false;
        Time.timeScale = 1f;    //Resume the game
        levelUpScreen.SetActive(false);
        ChangeState(GameState.Gameplay);
    }
}