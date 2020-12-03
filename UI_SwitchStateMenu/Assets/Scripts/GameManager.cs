using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager control = null;

    public GameObject TitleUI;
    public GameObject OptionsUI;
    public GameObject GameplayUI;
    public GameObject PauseUI;
    public GameObject GameOverUI;

    public GameObject Player;
    //adding map, inventory, stats
    public enum GameState { TitleScreen, Options, Gameplay, PauseMenu, GameOver};
    
    private GameState currentState;
    private GameState lastState;

    private void Awake()
    {
        if (control == null) {
           DontDestroyOnLoad(this);
           control = this;
        }
        else if(control != this) Destroy(this);
    }

    

    public void ChangeScene()
    {
        switch (currentState)
        {
            case GameState.TitleScreen:
                TitleUI.SetActive(true);
                PauseUI.SetActive(false);
                OptionsUI.SetActive(false);
                GameplayUI.SetActive(false);
                GameOverUI.SetActive(false);
                Player.SetActive(false);
                break;

            case GameState.Options:
                TitleUI.SetActive(false);
                PauseUI.SetActive(false);
                OptionsUI.SetActive(true);
                GameplayUI.SetActive(false);
                GameOverUI.SetActive(false);
                break;

            case GameState.Gameplay:
                TitleUI.SetActive(false);
                PauseUI.SetActive(false);
                OptionsUI.SetActive(false);
                GameplayUI.SetActive(true);
                GameOverUI.SetActive(false);
                Player.SetActive(true);
                break;

            case GameState.PauseMenu:
                TitleUI.SetActive(false);
                PauseUI.SetActive(true);
                OptionsUI.SetActive(false);
                GameplayUI.SetActive(false);
                GameOverUI.SetActive(false);
                break;

            case GameState.GameOver:
                TitleUI.SetActive(false);
                PauseUI.SetActive(false);
                OptionsUI.SetActive(false);
                GameplayUI.SetActive(false);
                GameOverUI.SetActive(true);
                Player.SetActive(false);
                break;
        }
    }

    public void OnGamePlay()
    {
        Time.timeScale = 1f;
        lastState = currentState;
        currentState = GameState.Gameplay;
        ChangeScene();
    }

    public void OnGameOver()
    {
        Time.timeScale = 1f;
        lastState = currentState;
        currentState = GameState.GameOver;
        ChangeScene();
    }

    public void OnPause()
    {
        Time.timeScale = 0f;
        lastState = currentState;
        currentState = GameState.PauseMenu;
        ChangeScene();
    }

    public void OpenOptions()
    {
        lastState = currentState;
        currentState = GameState.Options;
        ChangeScene();
    }

    public void ExitOptions()
    {
        currentState = lastState;
        ChangeScene();
    }

    public void OnResume()
    {
        Time.timeScale = 1f;
        lastState = currentState;
        currentState = GameState.Gameplay;
        ChangeScene();
    }

    public void ToTitleScreen()
    {
        Time.timeScale = 1f;
        lastState = currentState;
        currentState = GameState.TitleScreen;
        ChangeScene();
    }

    public void ExitAppllication()
    {
        Application.Quit();
    }
}
